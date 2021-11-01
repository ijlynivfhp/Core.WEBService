using ijlynivfhp.Core.WEBService.UserServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.UserServices.Services
{
    /// <summary>
    /// 商品服务接口
    /// </summary>
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(string UserName);
        User GetUserById(int id);
        void Create(User User);
        void Update(User User);
        void Delete(User User);
        bool UserExists(int id);
        bool UserNameExists(string UserName);
    }
}
