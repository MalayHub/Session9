using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/User2")]
    [ApiController]
    [ApiVersion("2")]
    public class User2Controller : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public User2Controller(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
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
            if (user==null)
            {
                return BadRequest("Kindly Register First.");
            }
            else if (user.Password == loginUser.Password)
            {
                return Ok(_tokenService.CreateToken(user.Email));
            }
            return BadRequest("Invalid Password.");
        }
    }
}
