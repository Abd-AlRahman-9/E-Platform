using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Learning_Platform.Core.Entities.Communication;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.MessageType).HasConversion<string>();
            builder.Property(m => m.Content).IsRequired().HasMaxLength(4000);
            builder.Property(m => m.ArrivedAt).IsRequired();
            builder.Property(m => m.SentIn).IsRequired();

            builder.HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(m => m.ConversationId);
            builder.HasIndex(m => m.SenderId);
        }
    }
}
