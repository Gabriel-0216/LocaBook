using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infra.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.UserName)
            .HasColumnName("UserName")
            .HasColumnType("nvarchar")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("varchar")
            .HasMaxLength(80)
            .IsRequired();
        
        builder.Property(p => p.LastName)
            .HasColumnName("LastName")
            .HasColumnType("varchar")
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(p => p.Email)
            .HasColumnName("Email")
            .HasColumnType("nvarchar")
            .HasMaxLength(80)
            .IsRequired();
        
        builder.Property(p => p.Cellphone)
            .HasColumnName("Cellphone")
            .HasColumnType("nvarchar")
            .HasMaxLength(11)
            .IsRequired();
        
        builder.Property(p => p.PasswordHash)
            .HasColumnName("PasswordHash")
            .HasColumnType("nvarchar")
            .IsRequired();

        builder.HasIndex(p => p.UserName)
            .IsUnique();

        builder.HasIndex(p => p.Email)
            .IsUnique();

        builder.HasIndex(p => p.Cellphone)
            .IsUnique();
        
        


    }
}