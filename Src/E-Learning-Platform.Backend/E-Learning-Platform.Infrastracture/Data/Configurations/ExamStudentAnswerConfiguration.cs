using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ExamStudentAnswerConfiguration : IEntityTypeConfiguration<ExamStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<ExamStudentAnswer> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SubmittedAt).IsRequired();
            builder.Property(x => x.Score).HasPrecision(5, 2);

            builder.HasOne(x => x.Student)
                .WithMany() // Student doesn't have StudentAnswers collection; keep relationship
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Question)
                .WithMany(q => q.StudentAnswers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.PracticeSession)
                .WithMany(p => p.StudentAnswers)
                .HasForeignKey(x => x.PracticeSessionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.OfficialExam)
                .WithMany(o => o.StudentAnswers)
                .HasForeignKey(x => x.OfficialExamId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
