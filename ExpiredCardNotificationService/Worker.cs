using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectManagement.Application.Common.Interfaces;
using ProjectManagement.Application.Model;

namespace ExpiredCardNotificationService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IEmailService emailService, IServiceProvider serviceProvider)
        {
            _logger = logger;

            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _emailHandler = scope.ServiceProvider.GetService<IEmailService>();

                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    var from = new List<EmailAddress>();
                    from.Add(new EmailAddress { Name = "dogukan", Address = "mail@dogukanurhan.com" });
                    _emailHandler.Send(new EmailMessage { 
                    Subject="test",
                    Content="test",
                    FromAddresses= from,
                        ToAddresses= from,

                    });
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }

    }
}
