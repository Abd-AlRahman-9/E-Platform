using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class OfficialExamConfiguration : IEntityTypeConfiguration<OfficialExam>
    {
        public void Configure(EntityTypeBuilder<OfficialExam> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.TargetType).HasConversion<string>();

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.OfficialExams)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
