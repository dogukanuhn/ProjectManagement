using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using ProjectManagement.Domain.Repositories;
using ProjectManagement.Infrastructure.Repositories;
using ProjectManagement.Application.Common.Interfaces;
using ExpiredCardNotificationService;

namespace ProjectManagement.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddHostedService<Worker>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));


            return services;
        }
    }
}
