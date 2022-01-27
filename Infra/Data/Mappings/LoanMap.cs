using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class LoanMap : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.ClientId)
                .IsRequired();


            builder.HasMany(p => p.Books)
                .WithMany(p => p.Loans)
                .UsingEntity<Dictionary<string, object>>("BookLoan",
                book => book.HasOne<Book>()
                .WithMany()
                .HasForeignKey("BookId")
                .HasConstraintName("FK_Loan_BookId")
                .OnDelete(DeleteBehavior.Cascade),
                loan => loan.HasOne<Loan>().WithMany()
                .HasForeignKey("LoanId")
                .HasConstraintName("FK_Book_Loan_LoanId")
                .OnDelete(DeleteBehavior.NoAction));
        }
    }
}
