using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class QuestionReviewConfiguration : IEntityTypeConfiguration<QuestionReview>
    {
        public void Configure(EntityTypeBuilder<QuestionReview> builder)
        {
            // choose composite key (QuestionId, ReviewedById, ReviewedAt) to allow multiple reviews
            builder.HasKey(x => new { x.QuestionId, x.ReviewedById, x.ReviewedAt });

            builder.Property(x => x.Comment).HasMaxLength(2000);
            builder.Property(x => x.ReviewedAt).IsRequired();

            builder.HasOne(x => x.Question)
                .WithMany(q => q.Reviews)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ReviewedBy)
                .WithMany()
                .HasForeignKey(x => x.ReviewedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.QuestionId);
            builder.HasIndex(x => x.ReviewedById);
        }
    }
}
