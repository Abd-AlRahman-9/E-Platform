using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Examination
{
    [Table("OfficialExamLessons", Schema = "Examination")]
    public class OfficialExamLesson : BaseAuditEntity
    {
        public int OfficialExamId { get; set; }
        public OfficialExam OfficialExam { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int? QuestionCount { get; set; }
        public decimal? Weight { get; set; }
    }

}
