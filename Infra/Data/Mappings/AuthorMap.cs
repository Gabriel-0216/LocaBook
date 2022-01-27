using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infra.Data.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder.HasMany(p => p.Books)
                .WithOne(p => p.Author)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => p.Id, "IX_Client_Id");

        }
    }
}
