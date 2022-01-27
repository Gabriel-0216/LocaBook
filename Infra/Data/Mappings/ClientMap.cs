using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(80);

            builder.Property(p => p.Cellphone)
                .HasColumnName("Cellphone")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.Property(p => p.CreateDate)
                .HasColumnName("CreateDate")
                .IsRequired()
                .HasColumnType("datetime");

            builder
                .HasIndex(p => p.Id, "IX_Client_Id");
            builder
                .HasIndex(p => p.Email, "IX_Client_Email")
                .IsUnique();

            builder
                .HasMany(p => p.Loans)
                .WithOne(p => p.Client);


        }
    }
}
