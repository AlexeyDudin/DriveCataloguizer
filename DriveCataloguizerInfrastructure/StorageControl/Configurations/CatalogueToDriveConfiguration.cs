using DriveCataloguizerModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveCataloguizerInfrastructure.StorageControl.Configurations
{
    public class CatalogueToDriveConfiguration : IEntityTypeConfiguration<CatalogueToDriveInformation>
    {
        public void Configure(EntityTypeBuilder<CatalogueToDriveInformation> builder)
        {
            builder.HasKey(cd => cd.Id);
            builder.Property(cd => cd.DrivePosition)
                .HasColumnName("drive_position");
            builder.HasOne(cd => cd.Catalogue).WithMany(c => c.Drives).HasForeignKey(cd => cd.CatalogueId);
        }
    }
}
