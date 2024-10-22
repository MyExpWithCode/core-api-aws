using core_api_aws.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace core_api_aws.ef.DAL
{
    public class EfContext : DbContext
    {
        
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> Classes { get; set; }

        public DbSet<ClassHistory> ClassesHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Database=sample;Username=postgres;Password=1In@Billion");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sample_poc");
            base.OnModelCreating(modelBuilder);
        }
    }
}
