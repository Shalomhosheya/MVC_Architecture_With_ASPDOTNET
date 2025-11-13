using Microsoft.EntityFrameworkCore;
using WebApplicationORM.Models;

namespace WebApplicationORM.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseMySqlIdentityColumn(); // MySQL-specific auto-increment
                
                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(255)
                    .IsRequired();
                
                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .HasMaxLength(255)
                    .IsRequired();
            });
        }
    }
}