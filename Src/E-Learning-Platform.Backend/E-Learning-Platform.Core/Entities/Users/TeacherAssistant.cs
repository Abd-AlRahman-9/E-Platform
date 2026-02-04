using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Users
{
    [Table("TeacherAssistants", Schema = "Users")]
    public class TeacherAssistant : BaseAuditEntity
    {
        // Composite key configured in DbContext: (TeacherId, AssistantId)
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int AssistantId { get; set; }
        public TeachingAssistant Assistant { get; set; }

        public DateTime JoinedAt { get; set; }
        public bool CanApproveStudents { get; set; }
        public bool CanApproveParents { get; set; }
        public bool CanManageQuestions { get; set; }
    }
}
