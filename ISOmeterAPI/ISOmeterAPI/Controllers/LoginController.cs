using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.UserDTOs;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace ISOmeterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            if (_userService.UserLogin(userLoginDTO))
            {
                return Ok("Sesion iniciada");
            }
            return BadRequest("Credenciales inválidas.");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDTO userDTO)
        {
            if (_userService.CreateUser(userDTO))
            {
                return Ok("Usuario registrado");
            }
            return BadRequest("Email en uso");
        }
    }
}
