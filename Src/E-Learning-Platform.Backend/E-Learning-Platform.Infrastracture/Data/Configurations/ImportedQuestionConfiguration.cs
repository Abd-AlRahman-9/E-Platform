using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ImportedQuestionConfiguration : IEntityTypeConfiguration<ImportedQuestion>
    {
        public void Configure(EntityTypeBuilder<ImportedQuestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasConversion<string>();
            builder.Property(x => x.ExtractedText).HasMaxLength(4000);
            builder.Property(x => x.CandidateOptionsJson).HasMaxLength(4000);
            builder.Property(x => x.ReviewNotes).HasMaxLength(2000);
            builder.Property(x=> x.IsValidated).IsRequired();
            builder.Property(x => x.IsValidated)
                .HasComputedColumnSql("CASE WHEN Status = 'Approved' THEN 1 ELSE 0 END");

            builder.HasOne(x => x.Batch)
                .WithMany(b => b.ImportedQuestions)
                .HasForeignKey(x => x.ImportedQuestionBatchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ImportedQuestionBatchId);
        }
    }
}
