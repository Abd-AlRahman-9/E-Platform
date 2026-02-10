using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Academic;
using WebApplication1.Models.Examination;

namespace WebApplication1.Models.Courseware
{
    [Table("Lessons", Schema = "Courseware")]
    public class Lesson : BaseEntity<int>
    {
        public Lesson()
        {
            ContentItems = new HashSet<ContentItem>();
            Questions = new HashSet<Question>();
            PracticeSessionLessons = new HashSet<PracticeSessionLesson>();
        }

        // link to the offered teacher-subject
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        public string Location { get; set; }

        public virtual ICollection<ContentItem> ContentItems { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        // explicit junction to PracticeSession (many-to-many with payload)
        public virtual ICollection<PracticeSessionLesson> PracticeSessionLessons { get; set; }
    }
}
