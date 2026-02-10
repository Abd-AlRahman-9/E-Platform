using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Courseware;
using WebApplication1.Models.Users;

namespace WebApplication1.Models.Examination
{
    [Table("ExamStudentAnswers", Schema = "Examination")]
    public class ExamStudentAnswer : BaseEntity<int>
    {
        // optional link to a practice session
        public int? PracticeSessionId { get; set; }
        public PracticeSession PracticeSession { get; set; }

        // optional link to an official exam
        public int? OfficialExamId { get; set; }
        public OfficialExam OfficialExam { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public string AnswerText { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public decimal? Score { get; set; }
    }
}