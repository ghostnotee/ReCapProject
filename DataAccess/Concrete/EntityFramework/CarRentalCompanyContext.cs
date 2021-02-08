using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalCompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost,1433;Database=CarRentalCompany;User=SA;Password=5uper5trongPW!"
            );
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}