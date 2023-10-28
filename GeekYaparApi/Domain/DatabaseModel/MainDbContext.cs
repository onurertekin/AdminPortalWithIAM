using DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModel
{
    public class MainDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
    }
}