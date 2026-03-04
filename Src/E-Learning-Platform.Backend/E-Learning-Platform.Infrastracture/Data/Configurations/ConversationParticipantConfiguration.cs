using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Communication;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class ConversationParticipantConfiguration : IEntityTypeConfiguration<ConversationParticipant>
    {
        public void Configure(EntityTypeBuilder<ConversationParticipant> builder)
        {
            // composite key
            builder.HasKey(cp => new { cp.ConversationId, cp.UserId });

            builder.Property(cp => cp.IsMuted).IsRequired();

            builder.HasOne(cp => cp.Conversation)
                .WithMany(c => c.ConversationParticipants)
                .HasForeignKey(cp => cp.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.User)
                .WithMany()
                .HasForeignKey(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(cp => cp.ConversationId);
            builder.HasIndex(cp => cp.UserId);
        }
    }
}
