using AutoMapper;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ijlynivfhp.Core.WEBService.Commons.Exceptions;
using ijlynivfhp.Core.WEBService.Cores.Middleware.Urls;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Dtos.UserService;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Forms.UserService;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services;
using ijlynivfhp.Core.WEBService.UserServices.Models;
using System;
using System.Net.Http;
using System.Security.Claims;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserClient userClient;
        private readonly IDynamicMiddleUrl dynamicMiddleUrl; // 中台url
        private readonly HttpClient httpClient;

        public UserController(IUserClient userClient, IDynamicMiddleUrl dynamicMiddleUrl
                                , IHttpClientFactory httpClientFactory)
        {
            this.userClient = userClient;
            this.dynamicMiddleUrl = dynamicMiddleUrl;
            this.httpClient = httpClientFactory.CreateClient();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        public UserDto PostLogin([FromForm]LoginPo loginPo)
        {
            // 1、查询用户信息 
            // 2、判断用户信息是否存在
            // 3、将用户信息生成token进行存储
            // 4、将token信息存储到cookie或者session中
            // 5、返回成功信息和token
            // 6、对于token进行认证(也就是身份认证)

            // 1、获取IdentityServer接口文档
            string userUrl = dynamicMiddleUrl.GetMiddleUrl("http", "UserServices");
            DiscoveryDocumentResponse discoveryDocument = httpClient.GetDiscoveryDocumentAsync(userUrl).Result;
            if (discoveryDocument.IsError)
            {
                Console.WriteLine($"[DiscoveryDocumentResponse Error]: {discoveryDocument.Error}");
            }

            // 2、根据用户名和密码建立token
            TokenResponse tokenResponse = httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client-password",
                ClientSecret = "secret",
                GrantType = "password",
                UserName = loginPo.UserName,
                Password = loginPo.Password
            }).Result;
            // 3、返回AccessToken
            if (tokenResponse.IsError)
            {
                throw new BizException(tokenResponse.Error + "," + tokenResponse.Raw);
            }

            // 4、获取用户信息
            UserInfoResponse userInfoResponse = httpClient.GetUserInfoAsync(new UserInfoRequest() {
                Address = discoveryDocument.UserInfoEndpoint,
                Token = tokenResponse.AccessToken
            }).Result;

            // 5、返回UserDto信息
            UserDto userDto = new UserDto();
            userDto.UserId = userInfoResponse.Json.TryGetString("sub");
            userDto.UserName = loginPo.UserName;
            userDto.AccessToken = tokenResponse.AccessToken;
            userDto.ExpiresIn = tokenResponse.ExpiresIn;

            // 1、加密方式有很多，证书加密，数据安全的

            // 1、cookie存储
            // 2、本地缓存

            return userDto;
        }


        public void ResfreshToken()
        {

        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userForm"></param>
        [HttpPost]
        public User Post([FromForm] UserPo userPo)
        {
            // 1、userForm 转换成领域模型
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserPo, User>();
            });

            IMapper mapper = configuration.CreateMapper();

            // 2、转换
            User user = mapper.Map<UserPo, User>(userPo);
            user.CreateTime = new DateTime();

            // 3、用户进行注册
            user = userClient.RegistryUsers(user);

            return user;
        }

    }
}
