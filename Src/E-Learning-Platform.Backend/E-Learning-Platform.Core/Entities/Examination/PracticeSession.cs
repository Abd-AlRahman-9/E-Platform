using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Courseware;
using WebApplication1.Models.Users;

namespace WebApplication1.Models.Examination
{
    [Table("PracticeSessions", Schema = "Examination")]
    public class PracticeSession : BaseEntity<int>
    {
        public PracticeSession()
        {
            StudentAnswers = new HashSet<ExamStudentAnswer>();
            PracticeSessionLessons = new HashSet<PracticeSessionLesson>();
        }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        // replaced single Lesson link with explicit many-to-many join
        public virtual ICollection<PracticeSessionLesson> PracticeSessionLessons { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }

        public virtual ICollection<ExamStudentAnswer> StudentAnswers { get; set; }
    }
}