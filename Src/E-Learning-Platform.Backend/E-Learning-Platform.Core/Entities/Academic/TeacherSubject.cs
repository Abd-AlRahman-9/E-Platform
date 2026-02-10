using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Courseware;
using WebApplication1.Models.Examination;
using WebApplication1.Models.Users;
using WebApplication1.Models.Operations;

namespace WebApplication1.Models.Academic
{
    [Table("TeacherSubjects", Schema = "Academic")]
    public class TeacherSubject : BaseEntity<int>
    {
        public TeacherSubject()
        {
            Lessons = new HashSet<Lesson>();
            OfficialExams = new HashSet<OfficialExam>();
            InvitationCodes = new HashSet<InvitationCode>();
            ParentApprovals = new HashSet<StudentParentApproval>();
        }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<OfficialExam> OfficialExams { get; set; }
        public virtual ICollection<InvitationCode> InvitationCodes { get; set; }

        // approvals by parents for this teacher-subject offering
        public virtual ICollection<StudentParentApproval> ParentApprovals { get; set; }
    }
}
