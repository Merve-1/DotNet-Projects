using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jym.DataAccess.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User> 
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
  
        builder.Property( u => u.Name)
            .HasMaxLength(100);
        
        builder.Property( u => u.Email)
            .HasMaxLength(100);
        
        builder.Property( u => u.Phone)
            .HasMaxLength(20);
        
        builder.Property(u => u.Gender)
            .HasConversion<string>()
            .HasMaxLength(20);
        
        builder.OwnsOne(x => x.Address, t =>
        {
            t.Property(a => a.Street)
                .HasColumnName("Street")
                .HasMaxLength(100);

            t.Property(a => a.City)
                .HasColumnName("City")
                .HasMaxLength(100);

            t.Property(a => a.BuildingNumber)
                .HasColumnName("BuildingNumber");
            
            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");
            
            builder.HasIndex(u => u.Phone)
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");
            
            
            //phone format
            // 010 011 012 015
            
            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_User_Phone",
                    "[Phone] LIKE '01[0125][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
            });

            builder.HasDiscriminator<string>("UserType")
                .HasValue<Member>(nameof(Member))
                .HasValue<Trainer>(nameof(Trainer));
            
            builder.HasQueryFilter(u => !u.IsDeleted);
        });
        //enum: as integer 0 1
        //users.tolist(); // softdeleted
        //builder.HasQueryFilter(u => !u.IsDeleted);
        
    }
}