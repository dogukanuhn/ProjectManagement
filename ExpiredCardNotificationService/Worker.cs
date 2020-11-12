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
using ProjectManagement.Domain.Repositories;

namespace ExpiredCardNotificationService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;

            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var _emailHandler = scope.ServiceProvider.GetService<IEmailService>();
                var _cardRepository = scope.ServiceProvider.GetService<ICardRepository>();

                var expiredList = _cardRepository.Get(x => x.ExpireTime < DateTime.Now && x.IsWarned == false);

                foreach (var item in expiredList)
                {

                    item.IsWarned = true;
                    await _cardRepository.UpdateAsync(item.Id, item);

                    var from = new List<EmailAddress>
                        {
                            new EmailAddress { Name = item.CreatedBy, Address = item.CreatedBy }
                        };

                    var to = new List<EmailAddress>
                        {
                            new EmailAddress { Name = item.CreatedBy, Address = item.NotificationEmail }
                        };

                    string subject = $"Expired Card : {item.Title}";


                    SendMail(_emailHandler, new EmailMessage
                    {
                        Subject = subject,
                        Content = subject,
                        FromAddresses = from,
                        ToAddresses = to

                    });
                    _logger.LogInformation($"Notification email sent to: {item.NotificationEmail}, from : {item.CreatedBy}, in : {DateTime.Now}");
                }


                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }

        void SendMail(IEmailService _emailService,EmailMessage message)
        {
         
            _emailService.Send(message);

        }

    }
}
