using laptop_service.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace laptop_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopRepository laptopRepository;

        public LaptopController(ILaptopRepository _laptopRepository)
        {
            laptopRepository = _laptopRepository;
        }

        [HttpGet("/api/laptops")]
        public IActionResult GetAll()
        {
            return Ok(laptopRepository.DisplayAllLaptops());
        }
    }
}
