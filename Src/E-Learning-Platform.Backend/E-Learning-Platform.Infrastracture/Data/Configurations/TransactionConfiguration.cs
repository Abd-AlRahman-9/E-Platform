using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Operations;

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
            builder.Property(x => x.PaymentMethod).HasConversion<string>();

            builder.HasOne(x => x.Payer)
                .WithMany()
                .HasForeignKey(x => x.PayerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StudentEnrollment)
                .WithMany(se => se.Transactions)
                .HasForeignKey(x => new {x.StudentId, x.TeacherSubjectId})
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
