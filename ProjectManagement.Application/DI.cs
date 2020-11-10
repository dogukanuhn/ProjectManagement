using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ProjectManagement.Domain.Common;
using ProjectManagement.Application.Common.Helpers;

namespace ProjectManagement.Application
{
   public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IApplicationUser, ApplicationUser>();

            return services;
        }
    }
}
