using BoOl.Application.Interfaces;
using BoOl.Application.Services.Customers;
using BoOl.Application.Services.CustomServices;
using BoOl.Application.Services.Models;
using BoOl.Application.Services.Orders;
using BoOl.Application.Services.Parts;
using BoOl.Application.Services.Positions;
using BoOl.Application.Services.Products;
using BoOl.Application.Services.Services;
using BoOl.Application.Services.Storages;
using BoOl.Application.Services.Users;
using BoOl.Application.Services.Workers;
using BoOl.Application.Validations.Customers;
using BoOl.Application.Validations.CustomServices;
using BoOl.Application.Validations.Models;
using BoOl.Application.Validations.Orders;
using BoOl.Application.Validations.Parts;
using BoOl.Application.Validations.Positions;
using BoOl.Application.Validations.Products;
using BoOl.Application.Validations.Services;
using BoOl.Application.Validations.Workers;
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
            services.AddTransient<ICustomerValidation, CustomerValidation>();
            services.AddTransient<ICustomServiceValidation, CustomServiceValidation>();
            services.AddTransient<IModelValidation, ModelValidation>();
            services.AddTransient<IOrderValidation, OrderValidation>();
            services.AddTransient<IPartValidation, PartValidation>();
            services.AddTransient<IPositionValidation, PositionValidation>();
            services.AddTransient<IProductValidation, ProductValidation>();
            services.AddTransient<IServiceValidation, ServiceValidation>();
            services.AddTransient<IStorageValidation, StorageValidation>();
            services.AddTransient<IWorkerValidation, WorkerValidation>();
            #endregion

            #region Services
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomServicesService, CustomServicesService>();
            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IStorageService, StorageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWorkerService, WorkerService>();
            #endregion

            #region Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomServiceRepository, CustomServiceRepository>();
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IStorageRepository, StorageRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPartRepository, PartRepository>();
            services.AddTransient<IPositionRepository, PositionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWorkerRepository, WorkerRepository>();
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
