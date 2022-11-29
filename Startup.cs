using BoOl.Application.Interfaces;
using BoOl.Application.Services.Customers;
using BoOl.Application.Services.Models;
using BoOl.Application.Services.Services;
using BoOl.Application.Services.Storages;
using BoOl.Application.Validations.Models;
using BoOl.Domain;
using BoOl.Persistence;
using BoOl.Persistence.DatabaseContext;
using BoOl.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BoOl
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
            services.Configure<DatabaseOptions>(Configuration.GetSection("DatabaseOptions"));
            services.AddDbContext<BoOlContext>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<BoOlContext>();
            services.AddRazorPages();

            #region Validation
            services.AddTransient<IModelValidation, ModelValidation>();
            #endregion

            #region Services
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IStorageService, StorageService>();
            #endregion

            #region Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IStorageRepository, StorageRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
