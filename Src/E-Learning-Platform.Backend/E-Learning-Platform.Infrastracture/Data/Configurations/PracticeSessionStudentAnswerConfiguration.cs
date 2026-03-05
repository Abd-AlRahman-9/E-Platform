using E_Learning_Platform.Core.Entities.Examination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class PracticeSessionStudentAnswerConfiguration : IEntityTypeConfiguration<PracticeSessionStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<PracticeSessionStudentAnswer> builder)
        {
            builder.HasKey(x=> new { x.StudentId,x.QuestionId,x.PracticeSessionId});

            builder.Property(x => x.SubmittedAt).IsRequired();
            builder.Property(x => x.Score).HasPrecision(5, 2);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentPracticeSessionAnswers)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Question)
                .WithMany(q => q.PracticeSessionStudentAnswers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PracticeSession)
                .WithMany(p => p.StudentAnswers)
                .HasForeignKey(x => x.PracticeSessionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
