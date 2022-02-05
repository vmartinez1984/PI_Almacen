using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkerService.Api.Services;

namespace WorkerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ILoggerService _loggerService;

        public LogController(ILogger<LogController> logger, ILoggerService loggerService)
        {
            _logger = logger;
            _loggerService = loggerService;
        }

        public LogController()
        {

        }

        [HttpGet]
        [Route("write/{cadena}")]
        public IActionResult Index(string cadena)
        {
            _logger.LogInformation("Entrando al controlador");
            _loggerService.WriteInLog(cadena);

            return Ok();
        }
    }
}
