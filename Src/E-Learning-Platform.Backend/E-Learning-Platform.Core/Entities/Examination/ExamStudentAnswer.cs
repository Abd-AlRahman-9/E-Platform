using System;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Users;

namespace E_Learning_Platform.Core.Entities.Examination
{
    [Table("ExamStudentAnswers", Schema = "Examination")]
    public class ExamStudentAnswer : StudentAnswer
    {
        public int OfficialExamId { get; set; }
        public OfficialExam OfficialExam { get; set; } = null!;
    }
}