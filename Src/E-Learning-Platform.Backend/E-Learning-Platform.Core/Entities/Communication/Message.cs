using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Communication
{
    public enum MessageType
    {
        Normal,
        Announcement,
        System,
    }
    [Table("Messages", Schema = "Communication")]
    public class Message:BaseEntity<long>
    {
        public MessageType MessageType { get; set; }
        public DateTime ArrivedAt { get; set; }
        public DateTime SentIn { get; set; }
        public bool IsEdited { get; set; }
        public DateTime? EditedAt { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public int ConversationId { get; set; } 
        public Conversation Conversation { get; set; }
    }
}
