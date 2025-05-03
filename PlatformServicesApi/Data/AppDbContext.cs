using Microsoft.EntityFrameworkCore;
using PlatformServicesApi.Models;

namespace PlatformServicesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> opt) :base(opt)
        { 
        }
        public DbSet<Platform> Platforms { get; set; } 
    }
}
