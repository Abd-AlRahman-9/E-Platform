using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Academic;
using WebApplication1.Models.Users;

namespace WebApplication1.Models.Operations
{
    [Table("StudentParentApprovals", Schema = "Operations")]
    public class StudentParentApproval : BaseAuditEntity
    {
        // Composite PK: StudentId, ParentId, TeacherSubjectId -> configure in DbContext
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; }

        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        public bool IsApproved { get; set; }
        public int? ApprovedByUserId { get; set; }
        public ApplicationUser ApprovedByUser { get; set; }
        public DateTime? ApprovedAt { get; set; }
    }
}