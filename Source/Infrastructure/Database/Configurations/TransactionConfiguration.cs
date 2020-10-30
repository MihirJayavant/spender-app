using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.HasOne(prop => prop.Division)
                .WithMany(prop => prop.Transactions)
                .HasForeignKey(prop => prop.DivisionId);
        }
    }
}
