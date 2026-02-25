using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ContentItemConfiguration : IEntityTypeConfiguration<ContentItem>
    {
        public void Configure(EntityTypeBuilder<ContentItem> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(2000);

            builder.HasOne(x => x.Lesson)
                .WithMany(l => l.ContentItems)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
