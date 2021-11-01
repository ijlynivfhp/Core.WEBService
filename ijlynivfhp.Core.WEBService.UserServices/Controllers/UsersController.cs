using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ijlynivfhp.Core.WEBService.Commons.Exceptions;
using ijlynivfhp.Core.WEBService.UserServices.Models;
using ijlynivfhp.Core.WEBService.UserServices.Services;
using System.Collections.Generic;
using System.Linq;

namespace ijlynivfhp.Core.WEBService.UserServices.Controllers
{
    /// <summary>
    /// 用户服务控制器
    /// </summary>
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService UserService;

        public UsersController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return UserService.GetUsers().ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var User = UserService.GetUserById(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            try
            {
                UserService.Update(User);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("更新成功");
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<User> PostUser(User User)
        {
            // 1、判断用户名是否重复
            if (UserService.UserNameExists(User.UserName))
            {
                throw new BizException("用户名已经存在");
            }
            UserService.Create(User);
            return CreatedAtAction("GetUser", new { id = User.Id }, User);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var User = UserService.GetUserById(id);
            if (User == null)
            {
                return NotFound();
            }

            UserService.Delete(User);
            return User;
        }

        private bool UserExists(int id)
        {
            return UserService.UserExists(id);
        }
    }
}
