using DriveCataloguizerModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveCataloguizerInfrastructure.StorageControl.Configurations
{
    public class CatalogueConfiguration : IEntityTypeConfiguration<CatalogueInformation>
    {
        public void Configure(EntityTypeBuilder<CatalogueInformation> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Number)
                .HasColumnName("number");
            builder.Property(c => c.Capacity)
                .HasColumnName("capacity");
        }
    }
}
