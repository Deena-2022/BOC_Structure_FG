using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Fg.FluentValidation
{
    public static class DependencyInjection
    {
        public static void AddValidations(this IServiceCollection services)
        {
            services.AddFluentValidation(F => F.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

        }
    }
}
