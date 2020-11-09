using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace ProjectManagement.Application
{
   public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
     
            return services;
        }
    }
}
