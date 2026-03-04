using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Communication
{
    [Table("ConverstionParticipants", Schema = "Communication")]
    public class ConversationParticipant : BaseAuditEntity
    {
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsMuted { get; set; }
        public DateTime? MutedUntil { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
