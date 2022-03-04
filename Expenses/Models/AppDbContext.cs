using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Expenses.Models
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Category> Category { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Period> Period { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
