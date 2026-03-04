using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Examination;
using E_Learning_Platform.Core.Entities.Users;
using E_Learning_Platform.Core.Entities.Operations;

namespace E_Learning_Platform.Core.Entities.Academic
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
            Enrollments = new HashSet<StudentEnrollmentProcess>();
            ImportedQuestionBatches = new HashSet<ImportedQuestionBatch>();
            ClassGroups = new HashSet<ClassGroup>();
        }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ClassGroup> ClassGroups { get; set; }
        public virtual ICollection<ImportedQuestionBatch> ImportedQuestionBatches { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<OfficialExam> OfficialExams { get; set; }
        public virtual ICollection<InvitationCode> InvitationCodes { get; set; }
        public virtual ICollection<StudentEnrollmentProcess> Enrollments { get; set; }
        // approvals by parents for this teacher-subject offering
        public virtual ICollection<StudentParentApproval> ParentApprovals { get; set; }
    }
}
