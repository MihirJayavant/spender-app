using Infrastructure.Database.Configurations;
using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "transaction.db3");

        //    optionsBuilder
        //        .UseSqlite($"Filename={dbPath}");
        //}
    }
}
