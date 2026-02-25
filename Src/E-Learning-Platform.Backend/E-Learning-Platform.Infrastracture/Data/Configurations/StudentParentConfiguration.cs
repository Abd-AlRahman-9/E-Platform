using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Users;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentParentConfiguration : IEntityTypeConfiguration<StudentParent>
    {
        public void Configure(EntityTypeBuilder<StudentParent> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => new { x.StudentId, x.ParentId });

            builder.HasOne(x => x.Student)
                .WithMany(s => s.Parents)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
