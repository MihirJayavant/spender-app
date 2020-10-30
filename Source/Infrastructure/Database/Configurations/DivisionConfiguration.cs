using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(prop => prop.User)
                .WithMany(prop => prop.Divisions)
                .HasForeignKey(prop => prop.UserId);
        }
    }
}
