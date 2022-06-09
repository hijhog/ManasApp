using ManasApp.Data.Contract.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManasApp.Data.Configurations
{
    public class LocalityConfiguration : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.NormalizedName).IsUnique();
            builder.Property(x => x.Description).IsRequired();

            builder.HasOne(x => x.Map).WithMany(x => x.Locality).HasForeignKey(x => x.MapId);
        }
    }
}
