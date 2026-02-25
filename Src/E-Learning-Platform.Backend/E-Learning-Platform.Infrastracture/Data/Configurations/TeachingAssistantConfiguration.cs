using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Users;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class TeachingAssistantConfiguration : IEntityTypeConfiguration<TeachingAssistant>
    {
        public void Configure(EntityTypeBuilder<TeachingAssistant> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);
        }
    }
}
