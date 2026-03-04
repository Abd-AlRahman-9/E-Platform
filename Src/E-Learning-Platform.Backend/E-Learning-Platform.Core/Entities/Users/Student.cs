using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Examination;
using E_Learning_Platform.Core.Entities.Operations;

namespace E_Learning_Platform.Core.Entities.Users
{
    [Table("Students", Schema = "Users")]
    public class Student : ApplicationUser
    {
        public Student()
        {
            Parents = new HashSet<StudentParent>();
            Enrollments = new HashSet<StudentEnrollmentProcess>();
            ProgressRecords = new HashSet<StudentProgress>();
            PracticeSessions = new HashSet<PracticeSession>();
            ParentApprovals = new HashSet<StudentParentApproval>();
            StudentClassGroups = new HashSet<StudentClassGroup>();
            StudentExamAnswers = new HashSet<ExamStudentAnswer>();
            StudentPracticeSessionAnswers = new HashSet<PracticeSessionStudentAnswer>();
            InvitationCodes = new HashSet<StudentInvitationCode>();
        }

        public DateTime DateOfBirth { get; set; }
        public string AcademicYear { get; set; }
        public virtual ICollection<StudentClassGroup> StudentClassGroups { get; set; } 
        public virtual ICollection<StudentParent> Parents { get; set; }
        public virtual ICollection<StudentEnrollmentProcess> Enrollments { get; set; }
        public virtual ICollection<StudentProgress> ProgressRecords { get; set; }

        // navigation for practice sessions started by student
        public virtual ICollection<PracticeSession> PracticeSessions { get; set; }
        public virtual ICollection<ExamStudentAnswer> StudentExamAnswers { get; set; }
        public virtual ICollection<StudentInvitationCode> InvitationCodes { get; set; }
        public virtual ICollection<PracticeSessionStudentAnswer> StudentPracticeSessionAnswers { get; set; }

        // per-TeacherSubject approvals for this student
        public virtual ICollection<StudentParentApproval> ParentApprovals { get; set; }
    }
}
