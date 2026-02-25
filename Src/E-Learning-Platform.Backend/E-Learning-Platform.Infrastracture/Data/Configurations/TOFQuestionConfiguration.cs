using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Courseware;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class TOFQuestionConfiguration : IEntityTypeConfiguration<TOFQuestion>
    {
        public void Configure(EntityTypeBuilder<TOFQuestion> builder)
        {
            builder.HasBaseType<MCQuestion>();
            // no extra fields
        }
    }
}
