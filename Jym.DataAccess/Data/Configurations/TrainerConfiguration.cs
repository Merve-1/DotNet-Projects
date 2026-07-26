using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jym.DataAccess.Data.Configurations;

public class TrainerConfiguration : UserConfiguration<Trainer>
    {
    public override void Configure(EntityTypeBuilder<Trainer> builder)
    {
        base.Configure(builder);
        
        //configuration related to "Trainer"
        builder.Property(p => p.Speciality)
            .HasConversion<string>()
            .HasMaxLength(30);

    }
}