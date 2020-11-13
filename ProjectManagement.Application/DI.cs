using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ProjectManagement.Domain.Common;
using ProjectManagement.Application.Common.Helpers;
using ProjectManagement.Application.Common.Interfaces;
using ProjectManagement.Application.Services;
using ProjectManagement.Application.PipelineBehaviours;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Application
{
   public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
         
            services.AddScoped<IJwtHandler, JwtHandler>();

            services.AddSingleton<IEmailService, EmailService>();

            services.AddScoped<IApplicationUser, ApplicationUser>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

   

        

            return services;
        }
    }
}
