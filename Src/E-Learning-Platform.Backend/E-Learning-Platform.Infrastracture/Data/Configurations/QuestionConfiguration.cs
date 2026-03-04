using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuestionType).HasConversion<string>();
            builder.Property(x => x.ApprovalStatus).HasConversion<string>();
            builder.Property(x => x.DifficultyLevel).HasConversion<string>();
            builder.Property(x => x.QuestionHeader).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.RightAnswer).HasMaxLength(2000);

            builder.HasOne(x => x.Lesson)
                .WithMany(l => l.Questions)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            // TPH discriminator
            builder.HasDiscriminator<QuestionType>(q=>q.QuestionType)
                .HasValue<Question>(QuestionType.Essay)
                .HasValue<TOFQuestion>(QuestionType.TOF) // default value ; specific derived types can be configured if needed
                .HasValue<MCQuestion>(QuestionType.MCQ);
        }
    }
}
