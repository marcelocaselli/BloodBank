using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangue.Infrastructure.Persistence
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donor> Donors { get; set; }       
        public DbSet<Stock> Stocks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Donation>(x =>
                {
                    x.HasKey(x => x.Id);                    
                });

            builder
                .Entity<Donor>(x =>
                {
                    x.HasKey(x => x.Id);

                    x.HasMany(x => x.Donations)
                        .WithOne(x => x.Donor)
                        .HasForeignKey(x => x.IdDonor)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.OwnsOne(x => x.Address, x =>
                    {
                        x.Property(x => x.Street).HasColumnName("Street");
                        x.Property(x => x.City).HasColumnName("City");
                        x.Property(x => x.State).HasColumnName("State");
                        x.Property(x => x.ZipCode).HasColumnName("ZipCode");
                    });

                });
            
            builder
                .Entity<Stock>(x =>
                {
                    x.HasKey(x => x.Id);
                });           

            base.OnModelCreating(builder);
        }
    }
}
