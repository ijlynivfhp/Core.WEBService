using Microsoft.EntityFrameworkCore;
using ijlynivfhp.Projects.UserServices.Models;

namespace ijlynivfhp.Projects.UserServices.Context
{
    /// <summary>
    /// 用户服务上下文
    /// </summary>
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        /// <summary>
        /// 用户集合
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
