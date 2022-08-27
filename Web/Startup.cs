using GP.Data;
using GP.Data.Infrastructure;
using GP.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Web
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
            

            services.AddScoped<ICategoryService, CategoryService>()
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
            .AddScoped<IDatabaseFactory,DatabaseFactory>();

            //
            services.AddScoped<IMedecinService, MedecinService>()
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
            .AddScoped<IDatabaseFactory, DatabaseFactory>();
            
            //////
            services.AddScoped<IPatientService, PatientService>()
          .AddTransient<IUnitOfWork, UnitOfWork>()
          .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
          .AddScoped<IDatabaseFactory, DatabaseFactory>();

            //////
            services.AddScoped<IDossierService, DossierService>()
          .AddTransient<IUnitOfWork, UnitOfWork>()
          .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
          .AddScoped<IDatabaseFactory, DatabaseFactory>();
            /////
            services.AddScoped<IConsultationService, ConsultationService>()
         .AddTransient<IUnitOfWork, UnitOfWork>()
         .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
         .AddScoped<IDatabaseFactory, DatabaseFactory>();
            //

            services.AddDbContext<ExamenContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=Index}/{id?}");
            });

           
        }
    }
}
