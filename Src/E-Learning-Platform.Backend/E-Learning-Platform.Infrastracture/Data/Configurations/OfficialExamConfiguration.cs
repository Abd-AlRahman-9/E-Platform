using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class OfficialExamConfiguration : IEntityTypeConfiguration<OfficialExam>
    {
        public void Configure(EntityTypeBuilder<OfficialExam> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ExamDate).IsRequired();

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.OfficialExams)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
