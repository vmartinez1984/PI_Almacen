using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMongoDb.Models;
using MvcMongoDb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        public BeerServices _beerServices;

        public BeersController(BeerServices beerServices)
        {
            _beerServices = beerServices;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    List<Beer> list;

        //    list = _beerServices.Get();

        //    return Ok(list);
        //}

        [HttpGet]
        public async Task<IActionResult> Post(Beer beer)
        {
            await _beerServices.AddAsync(beer);

            return Ok();
        }
    }
}
