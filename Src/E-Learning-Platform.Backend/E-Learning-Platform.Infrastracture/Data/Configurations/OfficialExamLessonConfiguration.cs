using E_Learning_Platform.Core.Entities.Examination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class OfficialExamLessonConfiguration : IEntityTypeConfiguration<OfficialExamLesson>
    {
        public void Configure(EntityTypeBuilder<OfficialExamLesson> builder)
        {
            builder.HasKey(x => new { x.OfficialExamId, x.LessonId });
            builder.Property(x => x.Weight).HasPrecision(18,2);
            builder.HasOne(x => x.OfficialExam)
                .WithMany(e => e.OfficialExamLessons)
                .HasForeignKey(x => x.OfficialExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Lesson)
                .WithMany(l => l.OfficialExamLessons)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
