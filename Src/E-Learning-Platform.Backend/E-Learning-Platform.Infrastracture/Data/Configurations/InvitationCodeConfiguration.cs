using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class InvitationCodeConfiguration : IEntityTypeConfiguration<InvitationCode>
    {
        public void Configure(EntityTypeBuilder<InvitationCode> builder)
        {
            // table mapping via attributes
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasOne(x => x.TeacherSubject)
                .WithMany(ts => ts.InvitationCodes)
                .HasForeignKey(x => x.TeacherSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
