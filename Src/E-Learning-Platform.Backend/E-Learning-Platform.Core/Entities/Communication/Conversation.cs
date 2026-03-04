using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Communication
{
    public enum ConversationType
    {
        Private,
        SubjectChannel,
        ClassGroupChannel,
        Broadcast
    }
    [Table("Conversations", Schema = "Communication")]
    public class Conversation : BaseEntity<int>
    {
        public Conversation()
        {
            ConversationParticipants = new HashSet<ConversationParticipant>();
            Messages = new HashSet<Message>();
        }
        public ConversationType ConversationType { get; set; }
        public int? TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
        public int? ClassGroupId { get; set; }
        public ClassGroup ClassGroup { get; set; }
        public virtual ICollection<ConversationParticipant> ConversationParticipants { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
