using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IES.Domain.DI;
using IES.Services.ServiceRegister;
using IES.DataContext.DataContext;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using System.IO;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
using Stripe;
using ECommerceShoppingCartASPNet5.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IES.Education.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();
            services.AddRepositories();
            services.AddServices();
            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddMvc();
            services.AddDbContext<IESEducationContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddControllers();
            //services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>() 
     //.AddEntityFrameworkStores<DbContext>();
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title="IES.API", Version="Test" });
            });
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => //CookieAuthenticationOptions
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = "sk_test_51L9YomCQUfUmRJDWAvG2E1oOhBLsJE7F9pvxNzH9uGImEX29UiA4G0rgKlz2voJQSTqAJXY5nnLHEKVTsrDLLTs400OgblLCF0";
            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            
        
             
            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        
        }
    }
}
