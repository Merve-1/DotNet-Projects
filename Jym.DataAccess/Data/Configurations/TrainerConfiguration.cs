using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jym.DataAccess.Data.Configurations;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        
        //configuration related to "Trainer"
        builder.Property(p => p.Speciality)
            .HasConversion<string>()
            .HasMaxLength(30);

    }
}