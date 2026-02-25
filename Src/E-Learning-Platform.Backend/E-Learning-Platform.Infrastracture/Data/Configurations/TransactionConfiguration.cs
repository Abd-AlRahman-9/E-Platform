using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount).HasPrecision(18, 2);
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.PaymentMethod).HasMaxLength(100);

            builder.HasOne(x => x.Payer)
                .WithMany()
                .HasForeignKey(x => x.PayerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StudentEnrollment)
                .WithMany(se => se.Transactions)
                .HasForeignKey(x => x.StudentEnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
