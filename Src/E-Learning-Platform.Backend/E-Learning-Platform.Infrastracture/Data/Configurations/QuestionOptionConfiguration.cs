using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OptionText).IsRequired().HasMaxLength(1000);

            builder.HasOne(x => x.MCQuestion)
                .WithMany(m => m.Options)
                .HasForeignKey(x => x.MCQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
