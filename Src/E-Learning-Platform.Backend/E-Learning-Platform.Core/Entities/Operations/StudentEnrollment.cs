using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Academic;
using WebApplication1.Models.Users;

namespace WebApplication1.Models.Operations
{
    public enum EnrollmentStatus { Pending, Active, Suspended }

    [Table("StudentEnrollments", Schema = "Operations")]
    public class StudentEnrollment : BaseAuditEntity
    {
        // Composite key configured in DbContext: (StudentId, TeacherSubjectId)
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        // New fields per requirements
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentDeadline { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }

        // FK to ApplicationUser.Id (int as requested)
        public int? ApprovedByUserId { get; set; }
        public ApplicationUser ApprovedByUser { get; set; }

        public StudentEnrollment()
        {
            Transactions = new HashSet<Transaction>();
        }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
