using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ProjectManagement.Domain.Common;
using ProjectManagement.Application.Common.Helpers;
using Microsoft.Extensions.Hosting;
using ExpiredCardNotificationService;

namespace ProjectManagement.Application
{
   public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHostedService<Worker>();

            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IApplicationUser, ApplicationUser>();

            return services;
        }
    }
}
