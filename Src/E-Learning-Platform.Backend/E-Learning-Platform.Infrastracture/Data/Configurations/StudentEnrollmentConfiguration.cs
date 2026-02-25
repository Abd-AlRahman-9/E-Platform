using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentEnrollmentConfiguration : IEntityTypeConfiguration<StudentEnrollment>
    {
        public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => new { x.StudentId, x.TeacherSubjectId });

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.IsPaid).IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.Enrollments)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
