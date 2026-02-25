using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Users;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.JoinDate).IsRequired();

            builder.HasMany(x => x.Subjects)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
