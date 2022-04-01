using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportLogistika.BL
{
    public class TLContext : DbContext
    {
        public DbSet<Driver> Driver { get; set; } = null!;
        public DbSet<Truck> Truck { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Service> Service { get; set; } = null!;

        public TLContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = USER-PC\MSSQLSERVER01; Database = TransportLogistikadb; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Take Configuretion

            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguretion());
            modelBuilder.ApplyConfiguration(new ServiceConfiguretion());
            modelBuilder.ApplyConfiguration(new TruckConfiguretion());

        }
    }

    //Add configuration for class Driver
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            //for Table
            builder.ToTable("Driver").Property(d => d.FistName).HasMaxLength(20);
            builder.ToTable("Driver").Property(d => d.LastName).HasMaxLength(20);
            builder.ToTable("Driver").Property(d => d.PhoneNumber_1).HasMaxLength(15);
            builder.ToTable("Driver").Property(d => d.PhoneNumber_2).HasMaxLength(15);
            builder.ToTable("Driver").Property(d => d.Email).HasMaxLength(500);
            builder.ToTable("Driver").Property(d => d.Category).HasMaxLength(30);
            builder.ToTable("Driver").Property(d => d.Country).HasMaxLength(50);
            builder.ToTable("Driver").Property(d => d.Region).HasMaxLength(100);
        }
    }

    //Add configuration for class Customer
    public class CustomerConfiguretion : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //for Table
            builder.ToTable("Customer").Property(c => c.FirstName).HasMaxLength(20);
            builder.ToTable("Customer").Property(c => c.LastName).HasMaxLength(20);
            builder.ToTable("Customer").Property(c => c.PhoneNumber_1).HasMaxLength(15);
            builder.ToTable("Customer").Property(c => c.PhoneNumber_2).HasMaxLength(15);
            builder.ToTable("Customer").Property(c => c.Email).HasMaxLength(500);
            builder.ToTable("Customer").Property(c => c.Country).HasMaxLength(50);
            builder.ToTable("Customer").Property(c => c.Region).HasMaxLength(50);
            builder.ToTable("Customer").Property(c => c.Addrress).HasMaxLength(110);
        }
    }

    //Add configuration for class Service
    public class ServiceConfiguretion : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            //for Table
            builder.ToTable("Service").Property(s => s.Name).HasMaxLength(20);
            builder.ToTable("Service").Property(s => s.Category).HasMaxLength(50);
            builder.ToTable("Service").Property(s => s.PhoneNumber_1).HasMaxLength(15);
            builder.ToTable("Service").Property(s => s.PhoneNumber_2).HasMaxLength(15);
            builder.ToTable("Service").Property(s => s.Website).HasMaxLength(300);
            builder.ToTable("Service").Property(s => s.Country).HasMaxLength(50);
            builder.ToTable("Service").Property(s => s.Region).HasMaxLength(50);
            builder.ToTable("Service").Property(s => s.Addrress).HasMaxLength(110);
        }

    }

    //Add configuration for class Truck
    public class TruckConfiguretion : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            //for Table
            builder.ToTable("Truck").Property(t => t.CarModel).HasMaxLength(50);
            builder.ToTable("Truck").Property(t => t.CarNumber).HasMaxLength(20);
            builder.ToTable("Truck").Property(t => t.MType).HasMaxLength(50);
            builder.ToTable("Truck").Property(t => t.Category).HasMaxLength(50);
            builder.ToTable("Truck").Property(t => t.GrossWeigh).HasMaxLength(20);
            builder.ToTable("Truck").Property(t => t.Year).HasMaxLength(15);
            builder.ToTable("Truck").Property(t => t.CurrentRegion).HasMaxLength(50);
            builder.ToTable("Truck").Property(t => t.Address).HasMaxLength(50);
        }
    }
}
