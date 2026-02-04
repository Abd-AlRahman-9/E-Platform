using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Examination;
using WebApplication1.Models.Operations;

namespace WebApplication1.Models.Users
{
    [Table("Students", Schema = "Users")]
    public class Student : ApplicationUser
    {
        public Student()
        {
            Parents = new HashSet<StudentParent>();
            Enrollments = new HashSet<StudentEnrollment>();
            ProgressRecords = new HashSet<StudentProgress>();
            PracticeSessions = new HashSet<PracticeSession>();
            ParentApprovals = new HashSet<StudentParentApproval>();
        }

        public DateTime DateOfBirth { get; set; }
        public string AcademicYear { get; set; }

        public virtual ICollection<StudentParent> Parents { get; set; }
        public virtual ICollection<StudentEnrollment> Enrollments { get; set; }
        public virtual ICollection<StudentProgress> ProgressRecords { get; set; }

        // navigation for practice sessions started by student
        public virtual ICollection<PracticeSession> PracticeSessions { get; set; }

        // per-TeacherSubject approvals for this student
        public virtual ICollection<StudentParentApproval> ParentApprovals { get; set; }
    }
}
