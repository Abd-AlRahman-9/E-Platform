using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Academic;

namespace E_Learning_Platform.Core.Entities.Examination
{
    public enum ExamTargetType
    {
        Subject,
        ClassGroup,
        SpecificStudents
    }
    [Table("OfficialExams", Schema = "Examination")]
    public class OfficialExam : BaseEntity<int>
    {
        public OfficialExam()
        {
            StudentAnswers = new HashSet<ExamStudentAnswer>();
            ExamQuestions = new HashSet<ExamQuestion>();
            OfficialExamStudents = new HashSet<OfficialExamStudent>();
            OfficialExamLessons = new HashSet<OfficialExamLesson>();
        }
        public ExamTargetType TargetType { get; set; }
        public string Title { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndAt { get; set; }
        public int DurationInMinutes { get; set; }
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
        public virtual ICollection<OfficialExamLesson> OfficialExamLessons { get; set; }
        public virtual ICollection<ExamStudentAnswer> StudentAnswers { get; set; }
        public virtual ICollection<OfficialExamStudent> OfficialExamStudents { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}