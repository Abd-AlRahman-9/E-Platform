using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Location).HasMaxLength(500);

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.Lessons)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
