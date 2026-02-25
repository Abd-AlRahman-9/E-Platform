using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Academic;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.HasOne(x => x.Track)
                .WithMany(t => t.Subjects)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
