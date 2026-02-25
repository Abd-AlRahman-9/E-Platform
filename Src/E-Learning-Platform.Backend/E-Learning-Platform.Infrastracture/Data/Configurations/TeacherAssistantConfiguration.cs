using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Users;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class TeacherAssistantConfiguration : IEntityTypeConfiguration<TeacherAssistant>
    {
        public void Configure(EntityTypeBuilder<TeacherAssistant> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => new { x.TeacherId, x.AssistantId });

            builder.HasOne(x => x.Teacher)
                .WithMany(t => t.Assistants)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Assistant)
                .WithMany(a => a.AssignedTeachers)
                .HasForeignKey(x => x.AssistantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.JoinedAt).IsRequired();
        }
    }
}
