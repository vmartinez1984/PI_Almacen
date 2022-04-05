using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMongoDb.Models;
using MvcMongoDb.Services;
using System.Collections.Generic;

namespace MvcMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        BeerServices _beerServices;

        public BeersController(BeerServices beerServices)
        {
            _beerServices = beerServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Beer> list;

            list = _beerServices.Get();

            return Ok(list);
        }
    }
}
