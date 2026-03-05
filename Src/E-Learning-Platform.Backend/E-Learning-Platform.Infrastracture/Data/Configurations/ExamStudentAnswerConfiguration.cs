using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ExamStudentAnswerConfiguration : IEntityTypeConfiguration<ExamStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<ExamStudentAnswer> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.QuestionId, x.OfficialExamId });

            builder.Property(x => x.SubmittedAt).IsRequired();
            builder.Property(x => x.Score).HasPrecision(5, 2);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentExamAnswers)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Question)
                .WithMany(q => q.ExamStudentAnswers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            // table mapping via attributes
            builder.HasOne(x => x.OfficialExam)
                .WithMany(o => o.StudentAnswers)
                .HasForeignKey(x => x.OfficialExamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
