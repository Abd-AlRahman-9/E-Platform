using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ImportedQuestionBatchConfiguration : IEntityTypeConfiguration<ImportedQuestionBatch>
    {
        public void Configure(EntityTypeBuilder<ImportedQuestionBatch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SourceFilePath).HasMaxLength(2000);
            builder.Property(x => x.ImportedAt).IsRequired();

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.ImportedQuestionBatches) 
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.TeacherSubjectId);
            builder.HasIndex(x => x.ImportedByUserId);
        }
    }
}
