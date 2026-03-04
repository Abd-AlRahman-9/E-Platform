using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Academic;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentClassGroupConfiguration : IEntityTypeConfiguration<StudentClassGroup>
    {
        public void Configure(EntityTypeBuilder<StudentClassGroup> builder)
        {
            // composite key for join/payload
            builder.HasKey(x => new { x.StudentId, x.ClassGroupId });

            builder.Property(x => x.JoinedAt).IsRequired();

            // relationship to Student (principal) - restrict to avoid accidental data loss
            builder.HasOne(x => x.Student)
                .WithMany(s=>s.StudentClassGroups)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // relationship to ClassGroup (principal) - cascade deletion of join rows when class group removed
            builder.HasOne(x => x.ClassGroup)
                .WithMany(cg => cg.StudentClassGroups)
                .HasForeignKey(x => x.ClassGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // index foreign keys
            builder.HasIndex(x => x.StudentId);
            builder.HasIndex(x => x.ClassGroupId);
        }
    }
}
