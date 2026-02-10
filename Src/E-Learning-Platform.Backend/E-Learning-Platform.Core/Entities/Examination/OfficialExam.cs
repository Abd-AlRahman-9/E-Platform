using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Academic;

namespace WebApplication1.Models.Examination
{
    [Table("OfficialExams", Schema = "Examination")]
    public class OfficialExam : BaseEntity<int>
    {
        public OfficialExam()
        {
            StudentAnswers = new HashSet<ExamStudentAnswer>();
        }

        public string Title { get; set; }
        public DateTime ExamDate { get; set; }

        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        public virtual ICollection<ExamStudentAnswer> StudentAnswers { get; set; }
    }
}