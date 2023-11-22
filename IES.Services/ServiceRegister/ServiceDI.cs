using IES.Services.Interfaces.Interfaces;
using IES.Services.Services;
using Microsoft.Extensions.DependencyInjection;
//using IES.DataContext.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IES.Services.Interfaces;
namespace IES.Services.ServiceRegister
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDealService, DealService>();
            return services;
        }
    }
}
