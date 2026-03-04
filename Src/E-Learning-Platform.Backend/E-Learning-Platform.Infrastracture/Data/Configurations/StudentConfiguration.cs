using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Users;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // table mapping via attribute
            builder.Property(x => x.DateOfBirth).IsRequired();

            builder.Property(x => x.AcademicYear).HasMaxLength(50);
        }
    }
}
