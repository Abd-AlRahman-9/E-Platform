using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Academic;

namespace WebApplication1.Models.Operations
{
    [Table("InvitationCodes", Schema = "Operations")]
    public class InvitationCode : BaseEntity<Guid>
    {
        // Guid PK provided by BaseEntity<Guid>
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        public bool IsActive { get; set; } = true;

        // Optional: additional operational fields you will probably want:
        // public DateTime? RedeemedAt { get; set; }
        // public int? RedeemedByStudentId { get; set; }
    }
}