using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;

namespace E_Learning_Platform.Core.Entities.Operations
{
    public enum EnrollmentStatus { Pending, Active, Suspended }
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed,
        Refunded
    }

    [Table("StudentEnrollmentProcesses", Schema = "Operations")]
    public class StudentEnrollmentProcess : BaseAuditEntity
    {
        // Composite key configured in DbContext: (StudentId, TeacherSubjectId)
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        public virtual ICollection<StudentClassGroup> StudentClassGroups { get; set; }
        // New fields per requirements
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime? PaidAt { get; set; }
        public string RejectionReason { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }

        // FK to ApplicationUser.Id (int as requested)
        public int? ApprovedByUserId { get; set; }
        public ApplicationUser ApprovedByUser { get; set; }

        public StudentEnrollmentProcess()
        {
            Transactions = new HashSet<Transaction>();
            StudentClassGroups = new HashSet<StudentClassGroup>();
        }
        public int? InvitationCodeId { get; set; }
        public InvitationCode InvitationCode { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
