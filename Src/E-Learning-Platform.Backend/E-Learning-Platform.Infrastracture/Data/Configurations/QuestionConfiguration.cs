using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.QuestionHeader).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.RightAnswer).HasMaxLength(2000);

            builder.HasOne(x => x.Lesson)
                .WithMany(l => l.Questions)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            // TPH discriminator
            builder.HasDiscriminator<int>("QuestionType")
                .HasValue<Question>((int)QuestionType.TOF - 0) // default value ; specific derived types can be configured if needed
                ;
        }
    }
}
