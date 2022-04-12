using ApiTest.Models;
using ApiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_beerService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Beer beer;

            beer = _beerService.Get(id);

            if (beer is null)
                return NotFound();
            else
                return Ok(beer);
        }

    }
}
