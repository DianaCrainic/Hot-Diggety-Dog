using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Resources;
using WebAPI.Services;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString(Constants.DefaultConnectionString));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(Constants.Origins, builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .WithExposedHeaders(Constants.NumberOfPagesHeader);
                });
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>))
                    .AddScoped(typeof(IJwtService), typeof(JwtService))
                    .AddScoped(typeof(ICsvService), typeof(CsvService))
                    .AddScoped(typeof(IRepository<Order>), typeof(OrdersRepository))
                    .Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseCors(Constants.Origins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
