using API_4BIO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_4BIO.Data
{
    public class ApplicationDB : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactInfo> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ApiDb"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Address)
                .WithOne(c => c.Client)
                .HasForeignKey<Address>(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Client>()
                .HasOne(c => c.ContactInfo)
                .WithOne(c => c.Client)
                .HasForeignKey<ContactInfo>(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
