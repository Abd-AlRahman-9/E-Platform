using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class PracticeSessionLessonConfiguration : IEntityTypeConfiguration<PracticeSessionLesson>
    {
        public void Configure(EntityTypeBuilder<PracticeSessionLesson> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => new { x.PracticeSessionId, x.LessonId });

            builder.HasOne(x => x.PracticeSession)
                .WithMany(p => p.PracticeSessionLessons)
                .HasForeignKey(x => x.PracticeSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Lesson)
                .WithMany(l => l.PracticeSessionLessons)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
