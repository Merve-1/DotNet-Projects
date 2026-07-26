using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jym.DataAccess.Data.Configurations;

public class BookingConfiguration: IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.Property(b => b.IsAttended)
            .IsRequired()
            .HasDefaultValue(false);
        builder.HasOne(b => b.Member)
            .WithMany(b => b.Bookings)
            .HasForeignKey(b => b.MemberId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(b => new
        {
            b.MemberId,
            b.SessionId
        }).IsUnique();
        
     
    }
}