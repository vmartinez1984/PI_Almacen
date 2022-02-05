using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Dapper.WebApi.Middlewares
{
    public class MyMiddleware
    {
        private RequestDelegate _next;
        private ILogger _logger;

        public MyMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger(typeof(MyMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            Guid traceId;

            traceId = Guid.NewGuid();
            _logger.LogTrace($"Request {traceId} iniciada");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            string elapseTime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            _logger.LogTrace($"La request {traceId} ha llevado {elapseTime}");
        }


    }
}
