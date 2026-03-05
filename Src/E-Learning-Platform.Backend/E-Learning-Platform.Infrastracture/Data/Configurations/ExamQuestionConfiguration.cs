using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.HasKey(x => new {x.QuestionId,x.OfficialExamId});

            builder.Property(x => x.Score).HasPrecision(5,2);

            builder.HasOne(x => x.Question)
                .WithMany(q => q.ExamQuestions)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OfficialExam)
                .WithMany(e => e.ExamQuestions)
                .HasForeignKey(x => x.OfficialExamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.QuestionId);
            builder.HasIndex(x => x.OfficialExamId);
        }
    }
}
