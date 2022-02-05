using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HolaMundo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidsController : ControllerBase
    {
        public ActionResult Get()
        {
            return Ok(new { Guid = Guid.NewGuid().ToString() });
        }
    }
}
