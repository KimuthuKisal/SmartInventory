using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartInventory.Application.Common.Behaviours;
using SmartInventory.Application.Common.Interfaces;
using SmartInventory.Application.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
