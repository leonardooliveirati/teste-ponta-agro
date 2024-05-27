using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime2");

                entity.Property(e => e.Status)
                      .HasConversion<int>();

                entity.Property(e => e.UserId)
                 .IsRequired(); 
            });
        }
    }
}
