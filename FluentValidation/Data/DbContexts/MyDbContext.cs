using Microsoft.EntityFrameworkCore;

namespace FluentValidation.Data.DbContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(""); // constr
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Surname).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(100); 
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Age).IsRequired();
        }
    }


}
