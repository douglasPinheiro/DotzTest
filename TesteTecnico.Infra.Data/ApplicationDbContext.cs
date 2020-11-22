using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            MapCompany(builder);
            MapTransaction(builder);
            MapWallet(builder);
            MapCategory(builder);
            MapOrder(builder);
            MapUser(builder);
        }

        private static void MapOrder(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasOne(d => d.Product);

            builder.Entity<Order>()
                .HasOne(d => d.Wallet);
        }

        private static void MapCategory(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasMany(d => d.SubCategories)
                .WithOne(d => d.Category);
        }

        private static void MapCompany(ModelBuilder builder)
        {
            builder.Entity<Company>()
                .HasOne(d => d.Address);

            builder.Entity<Company>()
                .HasMany(d => d.Products)
                .WithOne(d => d.Company);
        }

        private static void MapTransaction(ModelBuilder builder)
        {
            builder.Entity<Transaction>()
                .HasOne(d => d.Company)
                .WithMany(d => d.TransactionsHistory);

            builder.Entity<Transaction>()
                .HasOne(d => d.Product);
        }

        private static void MapWallet(ModelBuilder builder)
        {
            builder.Entity<Wallet>()
                .HasOne(d => d.User)
                .WithOne(d => d.Wallet);

            builder.Entity<Wallet>()
                .HasMany(d => d.TransactionsHistory)
                .WithOne(d => d.Wallet);

            //builder.Entity<Wallet>()
            //    .HasMany(d => d.DeliveryHistory)
            //    .WithOne(d => d.Wallet);
        }

        private static void MapUser(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(d => d.Address);

            builder.Entity<User>()
                .HasOne(d => d.Wallet)
                .WithOne(d => d.User)
                .HasForeignKey<Wallet>(d => d.UserId);
        }
    }
}
