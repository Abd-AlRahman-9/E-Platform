using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentEnrollmentConfiguration : IEntityTypeConfiguration<StudentEnrollmentProcess>
    {
        public void Configure(EntityTypeBuilder<StudentEnrollmentProcess> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => new { x.StudentId, x.TeacherSubjectId });

            builder.Property(x => x.Status).HasConversion<string>().IsRequired();
            builder.Property(x => x.PaymentStatus).HasConversion<string>();

            builder.HasIndex(x => x.Status);

            builder.HasOne(x => x.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.Enrollments)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
