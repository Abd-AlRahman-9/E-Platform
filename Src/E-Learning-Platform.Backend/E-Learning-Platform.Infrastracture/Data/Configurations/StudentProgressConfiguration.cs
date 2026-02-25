using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentProgressConfiguration : IEntityTypeConfiguration<StudentProgress>
    {
        public void Configure(EntityTypeBuilder<StudentProgress> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

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
