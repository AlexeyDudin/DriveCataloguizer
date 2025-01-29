using DriveCataloguizerModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriveCataloguizerInfrastructure.StorageControl.Configurations
{
    public class DriveConfiguration : IEntityTypeConfiguration<DriveInformation>
    {
        public void Configure(EntityTypeBuilder<DriveInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(d => d.DriveType)
                .HasColumnName("drive_type");
            builder.Property(d => d.DriveStatus)
                .HasColumnName("drive_status");
            builder.Property(d => d.MainNumber)
                .HasColumnName("number");
            builder.Property(d => d.SecondNumber)
                .HasColumnName("second_number");
            builder.HasOne(d => d.CatalogueToDrive)
                .WithOne(cd => cd.Drive)
                .HasForeignKey<CatalogueToDriveInformation>(cd => cd.DriveId)
                .IsRequired(false);
        }
    }
}
