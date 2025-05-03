using PlatformServicesApi.Models;

namespace PlatformServicesApi.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext appDbContext, bool isProd)
        {
            if (!appDbContext.Platforms.Any())
            {
                Console.WriteLine("Seeding Data...");
                appDbContext.AddRangeAsync(
                    new Platform() { Name = "Azure", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Docker Inc.", Cost = "Free" }
                );
                appDbContext.SaveChangesAsync();
            }
            else {
                Console.WriteLine("Data is present already");
            }
        }
    }
}
