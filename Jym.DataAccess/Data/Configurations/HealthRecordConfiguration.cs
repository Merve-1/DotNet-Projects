using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jym.DataAccess.Data.Configurations;

public class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
{
    public void Configure(EntityTypeBuilder<HealthRecord> builder)
    {
        builder.Property(x => x.Height)
            .HasPrecision(5, 2);
        
        builder.Property(x => x.Weight)
            .HasPrecision(5, 2)
            .HasMaxLength(50);

        builder.Property(x => x.BloodType)
            .HasConversion<string>()
            .HasMaxLength(50);
        
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_HealthRecord_Height",
                "[Height] > 0");
            t.HasCheckConstraint(
                "CK_HealthRecord_Weight",
                "[Weight] > 0");
        });
        builder.HasQueryFilter(x => !x.IsDeleted);

    }
    
}