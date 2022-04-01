using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportLogistika.BL
{
    public class TLContext : DbContext
    {
        public DbSet<User> User { get; set; } = null!;
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
            //  modelBuilder.Entity<User>(UserConfigure); //way 1 (using the method)

            modelBuilder.ApplyConfiguration(new DriverConfiguration()); //way 2 (using the class)
        }

        //Configuretion for class User
        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User").Property(u => u.CreateAt).HasDefaultValueSql("GETDATE('now')");
        }
    }

    //Configuretion for class Driver
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Driver").Property(d => d.FistName).HasMaxLength(20);
            builder.ToTable("Driver").Property(d => d.LastName).HasMaxLength(20);
            builder.ToTable("Driver").Property(d => d.PhoneNumber_1).HasDefaultValue(15);
            builder.ToTable("Driver").Property(d => d.PhoneNumber_2).HasDefaultValue(15);
            builder.ToTable("Driver").Property(d => d.Email).HasDefaultValue(2000);
            builder.ToTable("Driver").Property(d => d.Category).HasDefaultValue(30);
            builder.ToTable("Driver").Property(d => d.Country).HasDefaultValue(50);
            builder.ToTable("Driver").Property(d => d.Region).HasDefaultValue(100);

        }
    }

}
