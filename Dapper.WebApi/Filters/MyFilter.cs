using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Dapper.WebApi.Filters
{
    public class MyFilter: ActionFilterAttribute
    {
        private readonly ILogger<MyFilter> _logger;

        public MyFilter(ILogger<MyFilter> logger)
        {
                _logger = logger;   
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogTrace("Antes del método");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger?.LogTrace("Después de método");
            base.OnActionExecuted(context);
        }
    }
}
