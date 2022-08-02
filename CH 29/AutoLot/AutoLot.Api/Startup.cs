using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Initialization;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AutoLot.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(
            IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoLot.Api", Version = "v1" });
            });
            var connectionString = Configuration.GetConnectionString("AutoLot");
            services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure()));
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<ICreditRiskRepo, CreditRiskRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IMakeRepo, MakeRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped(typeof(IAppLogging<>), typeof(AppLogging<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                //If in development environment, display debug info
                app.UseDeveloperExceptionPage();
                //Initialize the database
                if (Configuration.GetValue<bool>("RebuildDataBase")) SampleDataInitializer.InitializeData(context);
                //Original code
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoLot.Api v1"));
            }

            //redirect http traffic to https
            app.UseHttpsRedirection();
            //opt-in to routing
            app.UseRouting();
            //enable authorization checks
            app.UseAuthorization();
            //opt-in to using endpoint routing
            //use attribute routing on controllers
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}