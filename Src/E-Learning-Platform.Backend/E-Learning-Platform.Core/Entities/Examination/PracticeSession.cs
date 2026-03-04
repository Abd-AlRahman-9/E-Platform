using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Users;

namespace E_Learning_Platform.Core.Entities.Examination
{
    [Table("PracticeSessions", Schema = "Examination")]
    public class PracticeSession : BaseEntity<int>
    {
        public PracticeSession()
        {
            StudentAnswers = new HashSet<PracticeSessionStudentAnswer>();
            PracticeSessionLessons = new HashSet<PracticeSessionLesson>();
        }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswer {  get; set; }
        public decimal Score { get; set; }
        // replaced single Lesson link with explicit many-to-many join
        public virtual ICollection<PracticeSessionLesson> PracticeSessionLessons { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }
        public virtual ICollection<PracticeSessionStudentAnswer> StudentAnswers { get; set; }
    }
}