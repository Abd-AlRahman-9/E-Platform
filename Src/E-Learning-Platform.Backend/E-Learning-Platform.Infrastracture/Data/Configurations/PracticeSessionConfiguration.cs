using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class PracticeSessionConfiguration : IEntityTypeConfiguration<PracticeSession>
    {
        public void Configure(EntityTypeBuilder<PracticeSession> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartedAt).IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(s => s.PracticeSessions)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
