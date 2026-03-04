using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Courseware;

namespace E_Learning_Platform.Core.Entities.Examination
{
    [Table("PracticeSessionLessons", Schema = "Examination")]
    public class PracticeSessionLesson : BaseAuditEntity
    {
        public int PracticeSessionId { get; set; }
        public PracticeSession PracticeSession { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public decimal Score { get; set; }
        public int QuestionsAttempted { get; set; }
    }
}
