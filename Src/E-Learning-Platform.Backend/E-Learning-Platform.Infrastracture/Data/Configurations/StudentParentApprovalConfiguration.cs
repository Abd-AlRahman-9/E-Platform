using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentParentApprovalConfiguration : IEntityTypeConfiguration<StudentParentApproval>
    {
        public void Configure(EntityTypeBuilder<StudentParentApproval> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => new { x.StudentId, x.ParentId, x.TeacherSubjectId });

            builder.HasOne(x => x.Student)
                .WithMany(s => s.ParentApprovals)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Parent)
                .WithMany(p => p.ChildApprovals)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.ParentApprovals)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
