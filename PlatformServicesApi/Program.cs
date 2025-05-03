using Microsoft.EntityFrameworkCore;
using PlatformServicesApi.Data;
using Microsoft.OpenApi.Models;

namespace PlatformServicesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<AppDbContext>(options =>
                             options.UseInMemoryDatabase("MyInMemoryDb"));
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PlatformServices API",
                    Version = "v1"
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();      // exposes /swagger/v1/swagger.json
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformServices API v1");
                    c.RoutePrefix = "swagger";  // or "" to host UI at the root
                });
                //app.Environment.IsProduction()
                PrepDb.PrepPopulation(app,false);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
