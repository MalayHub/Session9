using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    [ApiVersion("1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult Register(User user)
        {
            user.Email = user.Email.ToLower();
            user.CreatedOn = DateTime.Now;
            user.CreatedBy = user.Email;
            if (_userService.GetUserByEmail(user.Email)!=null)
            {
                return BadRequest("User Already Exists.");
            }
            return Ok(_userService.RegisterUser(user));
        }
        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn(LoginUser loginUser)
        {
            User user = _userService.GetUserByEmail(loginUser.Email.ToLower());
            if (user.Password == loginUser.Password)
            {
                return Ok(true);
            }
            return BadRequest("Invalid UserName or Password");
        }
    }
}
