﻿using Infrastructure.Database.Configurations;
using Infrastructure.Database.Entities;
using Infrastructure.Essentials;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class ApplicationContext : DbContext
    {
        readonly IDbOption option;

        public ApplicationContext(IDbOption option) : base()
            => this.option = option;

        public async Task EnsureCreated()
        {
            await Database.EnsureCreatedAsync();
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           string dbPath = Path.Combine(option.AppDataDirectory, option.DatabaseName);

           optionsBuilder
               .UseSqlite($"Filename={dbPath}");
        }
    }
}
