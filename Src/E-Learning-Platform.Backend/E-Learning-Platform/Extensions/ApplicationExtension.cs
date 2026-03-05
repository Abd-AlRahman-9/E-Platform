using E_Learning_Platform.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Platform.Extensions
{
    public static class ApplicationExtension
    {
        public static async Task MigrateAsync(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILogger<Program>>();
            try
            {
                var context = services.GetRequiredService<PlatformDbContext>();
                await context.Database.MigrateAsync();
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, $"{ex.Message}");
            }
        }
    }
}
