using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;

namespace AgencyWebApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // 1. Auto-register all validators from the current assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}