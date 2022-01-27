using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder.Property(p => p.Resume)
                .HasColumnName("Resume")
                .HasColumnType("Text");

            builder.Property(p => p.CreateDate)
                .HasColumnName("CreateDate")
                .HasColumnType("DATETIME");


            builder.HasOne(p => p.Author)
                .WithMany(p => p.Books)
                .HasConstraintName("FK_Book_AuthorId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Loans)
                .WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>("BookLoan",
                loan => loan.HasOne<Loan>().WithMany()
                .HasForeignKey("LoanId")
                .HasConstraintName("FK_Book_Loan_LoanId")
                .OnDelete(DeleteBehavior.NoAction),
                book => book.HasOne<Book>()
                .WithMany()
                .HasForeignKey("BookId")
                .HasConstraintName("FK_Loan_BookId")
                .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
