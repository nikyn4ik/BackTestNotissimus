using BackTestNotissimus.Models;
using Microsoft.EntityFrameworkCore;

namespace BackTestNotissimus.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Mouse> Mouses { get; set; }
    }
}
