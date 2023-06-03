using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RealEstateAgency.Models
{
    public class RealEstateAgencyContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<CustomerRequest> CustomerRequests { get; set; }

        public RealEstateAgencyContext(DbContextOptions<RealEstateAgencyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            Console.WriteLine("Database was created successfully");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Property>()
       .HasKey(p => p.PropertyID);
            // Дополнительные настройки для модели Identity

            // Пример: Изменение имени таблицы пользователей
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            Console.WriteLine("IdentityUser entity was created successfully");

        }
    }
}
