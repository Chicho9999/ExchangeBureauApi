using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExchangeBureauxApi.Data.Models
{
    public class CurrencyExchangeDbContext : DbContext
    {
        public CurrencyExchangeDbContext(DbContextOptions<CurrencyExchangeDbContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LimitPucharse> LimitPucharses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasMany(e => e.FromCurrencyExchanges)
                .WithOne(e => e.CurrencyFrom)
                .HasForeignKey(e => e.CurrencyFromId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Currency>()
                .HasMany(e => e.ToCurrencyExchanges)
                .WithOne(e => e.CurrencyTo)
                .HasForeignKey(e => e.CurrencyToId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Currency>()
                .HasMany(e => e.FromTransactions)
                .WithOne(e => e.CurrencyFrom)
                .HasForeignKey(e => e.CurrencyFromId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Currency>()
                .HasMany(e => e.ToTransactions)
                .WithOne(e => e.CurrencyTo)
                .HasForeignKey(e => e.CurrencyToId)
                .OnDelete(DeleteBehavior.NoAction);

            var passwordHasher = new PasswordHasher<User>();
            var user = new User()
            {
                UserId = 1,
                FirstName = "Lisandro",
                LastName = "Chichi",
                Username = "LisandroAdmin",
                Email = "lisandrochichi@gmail.com",
                Address = "Rivadavia",
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            var hashedPassword = passwordHasher.HashPassword(user, "admin123.");
            user.Password = hashedPassword;

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    CurrencyId = 1,
                    Name = "DOLAR",
                    Identifier = "USD",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                },
                new Currency
                {
                    CurrencyId = 2,
                    Name = "REAL",
                    Identifier = "BRL",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                },
                new Currency
                {
                    CurrencyId = 3,
                    Name = "PESO ARGENTINO",
                    Identifier = "ARS",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<LimitPucharse>().HasData(
                new LimitPucharse
                {
                    CurrencyId = 1,
                    MaxAmountToBuy = 200,
                    UserId = 1,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                },
                new LimitPucharse
                {
                    CurrencyId = 2,
                    MaxAmountToBuy = 300,
                    UserId = 1,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<CurrencyExchange>().HasData(
                new CurrencyExchange
                {
                    CurrencyExchangeId = 1,
                    InverseConversionValue = 77.47,
                    ConversionValue = 83.86,
                    CurrencyFromId = 3,
                    CurrencyToId = 1,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                },
                new CurrencyExchange
                {
                    CurrencyExchangeId = 2,
                    InverseConversionValue = 83.86,
                    ConversionValue = 77.47,
                    CurrencyFromId = 1,
                    CurrencyToId = 3,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                },
                new CurrencyExchange
                {
                    CurrencyExchangeId = 3,
                    InverseConversionValue = 12.53,
                    ConversionValue = 14.04,
                    CurrencyFromId = 3,
                    CurrencyToId = 2,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                },
                new CurrencyExchange
                {
                    CurrencyExchangeId = 4,
                    InverseConversionValue = 14.04,
                    ConversionValue = 12.53,
                    CurrencyFromId = 2,
                    CurrencyToId = 3,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}