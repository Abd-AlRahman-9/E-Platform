using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Academic;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class TeacherSubjectConfiguration : IEntityTypeConfiguration<TeacherSubject>
    {
        public void Configure(EntityTypeBuilder<TeacherSubject> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(2000);

            builder.HasOne(x => x.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Semester)
                .WithMany(s => s.TeacherSubjects)
                .HasForeignKey(x => x.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subject)
                .WithMany(s => s.TeacherSubjects)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
