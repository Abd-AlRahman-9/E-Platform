using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentProgressConfiguration : IEntityTypeConfiguration<StudentProgress>
    {
        public void Configure(EntityTypeBuilder<StudentProgress> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).HasConversion<string>();
            builder.Property(x => x.Interactions).HasConversion<int>();

            builder.HasIndex(x => new { x.StudentId, x.ContentItemId });

            builder.HasOne(x => x.ContentItem)
                .WithMany(c => c.StudentProgresses)
                .HasForeignKey(x => x.ContentItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Student)
                .WithMany(s => s.ProgressRecords)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
