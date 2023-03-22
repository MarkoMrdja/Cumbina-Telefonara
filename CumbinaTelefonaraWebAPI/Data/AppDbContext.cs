using CumbinaTelefonaraWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CumbinaTelefonaraWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
    }
}
