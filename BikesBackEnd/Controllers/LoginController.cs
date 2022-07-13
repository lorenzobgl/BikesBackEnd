using BikesBackEnd.Models;
using BikesBackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikesBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UtenteServices _userService;

        public LoginController(UtenteServices userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult UserLogin([FromBody] Utente utente)
        {
            bool utentetrovato = _userService.CheckUser(utente.Username, utente.Password);
            return Ok(utentetrovato);
        }
    }
}
