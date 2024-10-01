using ISOmeterAPI.Data.Models.UserDTOs;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISOmeterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("user")]
        public IActionResult GetUser(string email)
        {
            try
            {
                return Ok(_userService.GetUserByEmail(email));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userService.DeleteUser(id))
            {
                return Ok("El usuario fue eliminado correctamente");
            }
            return BadRequest("El usuario no fue encontrado");
        }
    }
}
