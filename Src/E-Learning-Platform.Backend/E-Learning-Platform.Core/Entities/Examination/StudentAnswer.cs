using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Examination
{
    [Table("StudentAnswers", Schema = "Examination")]
    public abstract class StudentAnswer : BaseAuditEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public decimal? Score { get; set; }
    }
}
