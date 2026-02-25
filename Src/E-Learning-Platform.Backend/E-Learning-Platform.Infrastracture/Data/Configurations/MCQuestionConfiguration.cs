using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class MCQuestionConfiguration : IEntityTypeConfiguration<MCQuestion>
    {
        public void Configure(EntityTypeBuilder<MCQuestion> builder)
        {
            // inherits Questions table via TPH; no separate table
            builder.HasBaseType<Question>();

            builder.HasMany(m => m.Options)
                .WithOne(o => o.MCQuestion)
                .HasForeignKey(o => o.MCQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
