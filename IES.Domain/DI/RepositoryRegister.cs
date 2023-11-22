using IES.DataContext.DataContext;
using IES.Domain.Entities.Models;
using IES.Domain.Interfaces;
using IES.Domain.Interfaces.Interfaces;
using IES.Domain.Interfaces.UnitOfWork;
using IES.Domain.Repositories;
using IES.Domain.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.DI
{
    public static class RepositoryRegister
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository,CompanyRepository>();
            services.AddScoped<IDealRepository, DealRepository>();
            services.AddScoped<IdentityRoleManager>();
            services.AddScoped<IdentityUserManager>();
            services.AddIdentityCore<User>().AddRoles<IdentityRole>().AddEntityFrameworkStores<IESEducationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;

        }
    }
}
