using MuhinAlexandrYurevichKT_31_20.Database.Configurations;
using MuhinAlexandrYurevichKT_31_20.Models;
using Microsoft.EntityFrameworkCore;

namespace MuhinAlexandrYurevichKT_31_20.Database
{
    public class MuhinDbContext : DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());

        }

        public MuhinDbContext(DbContextOptions<MuhinDbContext> options) : base(options)
        {
        }
    }
}
