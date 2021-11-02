using ijlynivfhp.Projects.UserServices.Models;
using ijlynivfhp.Projects.UserServices.Repositories;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.UserServices.Services
{
    /// <summary>
    /// 商品服务实现
    /// </summary>
    public class UserServiceImpl : IUserService
    {
        public readonly IUserRepository UserRepository;

        public UserServiceImpl(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }

        public void Create(User User)
        {
            UserRepository.Create(User);
        }

        public void Delete(User User)
        {
            UserRepository.Delete(User);
        }

        public User GetUser(string UserName)
        {
            return UserRepository.GetUser(UserName);
        }

        public User GetUserById(int id)
        {
            return UserRepository.GetUserById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return UserRepository.GetUsers();
        }

        public void Update(User User)
        {
            UserRepository.Update(User);
        }

        public bool UserExists(int id)
        {
            return UserRepository.UserExists(id);
        }

        public bool UserNameExists(string UserName)
        {
            return UserRepository.UserNameExists(UserName);
        }
    }
}
