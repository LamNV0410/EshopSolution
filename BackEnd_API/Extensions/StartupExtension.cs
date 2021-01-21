using Application_Services;
using Application_Services.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_API.Extensions
{
    public static class StartupExtension
    {
        public static void InjectDependency(IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
        }
    }
}
