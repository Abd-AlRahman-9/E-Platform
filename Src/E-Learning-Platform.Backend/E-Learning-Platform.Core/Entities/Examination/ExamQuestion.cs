using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Examination
{
    [Table("ExamQuestions", Schema = "Examination")]
    public class ExamQuestion : BaseAuditEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int OfficialExamId { get; set; }
        public OfficialExam OfficialExam { get; set; }
        public int Order {  get; set; }
        public decimal Score { get; set; }
        public bool IsMandatory { get; set; }
        public DifficultyLevel DifficultyOverride { get; set; }
    }
}
