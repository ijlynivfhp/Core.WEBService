﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.UserServices.Configs
{
    public class Config
    {
        /// <summary>
        /// 1、微服务API资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("TeamService", "TeamService")
            };
        }

        /// <summary>
        /// 2、客户端
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client-password",
	                // 使用用户名密码交互式验证
	                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

	                // 用于认证的密码
	                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
	                // 客户端有权访问的范围（Scopes）
	                AllowedScopes = { "TeamService",
                    IdentityServerConstants.StandardScopes.OpenId, //必须要添加，否则报forbidden错误
                    IdentityServerConstants.StandardScopes.Profile }
                },
                // openid客户端
                new Client
                {
                    ClientId="client-code",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Code,
                    RequireConsent=false,
                    RequirePkce=true,

                    RedirectUris={ "https://localhost:5006/signin-oidc"}, // 1、客户端地址

                    PostLogoutRedirectUris={ "https://localhost:5006/signout-callback-oidc"},// 2、登录退出地址

                    AllowedScopes=new List<string>{
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "TeamService" // 启用服务授权支持
                    },

                    // 增加授权访问
                    AllowOfflineAccess=true
                }
            };
        }

        /// <summary>
        /// 2.1 openid身份资源
        /// </summary>
        public static IEnumerable<IdentityResource> Ids => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        /// <summary>
        /// 3、测试用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId="22222222",
                    Username="3333",
                    Password="22222"
                }
            };
        }
    }
}
