using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace IHostedServiceDemo.Services
{
    public class WriteToFileHostedService2: IHostedService,IDisposable
    {
        private readonly IHostingEnvironment _environment;
        private readonly string _filePath = "File2.txt";
        private Timer _timer;

        public WriteToFileHostedService2(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public void DoWork(object state)
        {
            WriteToFile("WriteToFileHostedService: Doing some work");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("WriteToFileHostedService: Process Start");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("WriteToFileHostedService: Process Stoped");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void WriteToFile(string message)
        {
            var path = $@"{_environment.ContentRootPath}\wwwroot\{_filePath}";

            using (var writer = new StreamWriter(path, append:true))
            {
                writer.WriteLine($"{DateTime.Now}-> {message}");
            }
        }
    }
}
