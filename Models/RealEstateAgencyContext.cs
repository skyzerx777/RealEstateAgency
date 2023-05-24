using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;

namespace RealEstateAgency.Models
{
    public class RealEstateAgencyContext : DbContext
    {
        public RealEstateAgencyContext(DbContextOptions<RealEstateAgencyContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<CustomerRequest> CustomerRequests { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
