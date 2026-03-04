using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Examination;

namespace E_Learning_Platform.Core.Entities.Courseware
{
    [Table("Lessons", Schema = "Courseware")]
    public class Lesson : BaseEntity<int>
    {
        public Lesson()
        {
            ContentItems = new HashSet<ContentItem>();
            Questions = new HashSet<Question>();
            PracticeSessionLessons = new HashSet<PracticeSessionLesson>();
            OfficialExamLessons = new HashSet<OfficialExamLesson>();
        }

        // link to the offered teacher-subject
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
        public int Order {  get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public virtual ICollection<ContentItem> ContentItems { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<OfficialExamLesson> OfficialExamLessons { get; set; }

        // explicit junction to PracticeSession (many-to-many with payload)
        public virtual ICollection<PracticeSessionLesson> PracticeSessionLessons { get; set; }
    }
}
