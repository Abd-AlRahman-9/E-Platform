using E_Learning_Platform.Extensions;
using E_Learning_Platform.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Platform
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<PlatformDbContext>(
                opt => opt.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection"
                        )
                    )
                );

            var app = builder.Build();

            await app.MigrateAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
