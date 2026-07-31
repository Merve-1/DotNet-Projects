using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jym.DataAccess.Data.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>

{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        
        //configuration related to "Members"
        builder.Property(p => p.Photo)
            .HasMaxLength(500);
    }
}