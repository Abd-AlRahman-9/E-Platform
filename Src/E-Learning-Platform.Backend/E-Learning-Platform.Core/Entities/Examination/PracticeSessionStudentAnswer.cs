using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Examination
{
    [Table("PracticeSessionStudentAnswers", Schema = "Examination")]
    public class PracticeSessionStudentAnswer:StudentAnswer
    {
        public int PracticeSessionId { get; set; }
        public PracticeSession PracticeSession { get; set; } = null!;

    }
}
