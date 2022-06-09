using ManasApp.Data.Contract.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManasApp.Data.Configurations
{
    public class StorageDataConfiguration : IEntityTypeConfiguration<StorageData>
    {
        public void Configure(EntityTypeBuilder<StorageData> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x=>x.UrlAddress).IsRequired();
            builder.Property(x=>x.StorageType).IsRequired();

            builder.HasOne(x => x.Locality).WithMany(x => x.StorageData).HasForeignKey(x => x.LocalityId);
        }
    }
}
