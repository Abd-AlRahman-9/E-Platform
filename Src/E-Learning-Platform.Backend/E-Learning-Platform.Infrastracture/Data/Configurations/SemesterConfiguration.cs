using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Academic;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.AcademicYear)
                .WithMany(y => y.Semesters)
                .HasForeignKey(x => x.AcademicYearId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
