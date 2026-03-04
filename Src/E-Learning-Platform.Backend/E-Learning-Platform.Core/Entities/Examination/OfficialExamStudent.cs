using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Examination
{
    // دا علشان لو حددنا إن الإمتحان هيكون لطلاب محددين
    [Table("OfficialExamStudents", Schema = "Examination")]
    public class OfficialExamStudent : BaseAuditEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int OfficialExamId { get; set; }
        public OfficialExam OfficialExam { get; set; }
    }
}
