using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class OfficialExamStudentConfiguration : IEntityTypeConfiguration<OfficialExamStudent>
    {
        public void Configure(EntityTypeBuilder<OfficialExamStudent> builder)
        {
            builder.HasKey(o => new { o.OfficialExamId, o.StudentId });

            builder.HasOne(o => o.OfficialExam)
                .WithMany(e => e.OfficialExamStudents)
                .HasForeignKey(o => o.OfficialExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Student)
                .WithMany()
                .HasForeignKey(o => o.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(o => o.OfficialExamId);
            builder.HasIndex(o => o.StudentId);
        }
    }
}
