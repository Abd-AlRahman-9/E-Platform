using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Academic;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ClassGroupConfiguration : IEntityTypeConfiguration<ClassGroup>
    {
        public void Configure(EntityTypeBuilder<ClassGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.ClassGroups)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.StudentClassGroups)
                .WithOne(scg => scg.ClassGroup)
                .HasForeignKey(scg => scg.ClassGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.TeacherSubjectId);
        }
    }
}
