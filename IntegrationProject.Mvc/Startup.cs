using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Mvc
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
            services.AddControllersWithViews();
            services.AddScoped<Contracts.IUnitOfWork, Repository.UnitOfWork>();
            services.AddScoped<Contracts.IServices.IServiceFactory, Services.ServiceFactory>();
            //services.AddScoped<Contracts.IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<Repository.UnitOfWork>();
            services.AddScoped<Repository.CompanyRepository>();
            services.AddScoped<Services.CompanyService>();
            services.AddScoped<Services.ServiceFactory>();

            AddMaps(services);
        }

        private void AddMaps(IServiceCollection services)
        {
            var mapperConfig = new AutoMapper.MapperConfiguration(mapper =>
            {
                mapper.AddProfile<Mappers.CompanyMapper>();
            });
            AutoMapper.IMapper mapper = mapperConfig.CreateMapper();    
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
