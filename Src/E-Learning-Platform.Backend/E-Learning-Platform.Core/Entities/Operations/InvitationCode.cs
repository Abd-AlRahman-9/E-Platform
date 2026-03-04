using System;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Academic;

namespace E_Learning_Platform.Core.Entities.Operations
{
    [Table("InvitationCodes", Schema = "Operations")]
    public class InvitationCode : BaseEntity<int>
    {
        // Guid PK provided by BaseEntity<Guid>
        public string Code { get; set; }
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int UsageLimit { get; set; }
        public int UsageCount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}