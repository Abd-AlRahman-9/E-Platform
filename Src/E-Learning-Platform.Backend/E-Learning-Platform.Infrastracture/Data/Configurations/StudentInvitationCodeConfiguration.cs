using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Operations;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentInvitationCodeConfiguration : IEntityTypeConfiguration<StudentInvitationCode>
    {
        public void Configure(EntityTypeBuilder<StudentInvitationCode> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.InvitationCodeId });

            builder.Property(x => x.RedeemedAt).IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(s => s.InvitationCodes)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InvitationCode)
                .WithMany()
                .HasForeignKey(x => x.InvitationCodeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.StudentId);
            builder.HasIndex(x => x.InvitationCodeId);
        }
    }
}
