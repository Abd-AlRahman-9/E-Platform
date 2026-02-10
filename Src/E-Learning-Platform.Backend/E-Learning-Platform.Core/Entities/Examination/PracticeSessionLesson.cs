using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Courseware;

namespace WebApplication1.Models.Examination
{
    [Table("PracticeSessionLessons", Schema = "Examination")]
    public class PracticeSessionLesson : BaseAuditEntity
    {
        public int PracticeSessionId { get; set; }
        public PracticeSession PracticeSession { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int QuestionsAttempted { get; set; }
    }
}
