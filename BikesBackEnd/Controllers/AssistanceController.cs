using BikesBackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikesBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistanceController : ControllerBase
    {
        private readonly BikeServices _bikeService;

        public AssistanceController(BikeServices bikeServices)
        {
            _bikeService = bikeServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("qui ci va il form?");
        }


        [HttpGet("{id}")]
        public IActionResult Confirmed(Guid id)
        {
            var bike = _bikeService.findBikebyId(id);
            if (bike == null)
            {
                return NotFound();
            }
            else
            {
                _bikeService.ChangeStatus(bike);
            }
            //e poi si dovrebbe chiamare l'assistenza per davvero
            return Ok("Grazie! Abbiamo chiamato l'assistenza che ti contatterà a breve. In caso contrario chiama il seguente numero: 33458238474");
        }
    }
}
