using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Operations;

namespace WebApplication1.Models.Courseware
{
    public enum ContentType
    {
        Video,
        Pdf,
        Article,
        Presentation,
        Audio,
        Image,
        Link,
        RecordedMeeting,
    }

    [Table("ContentItems", Schema = "Courseware")]
    public class ContentItem : BaseEntity<int>
    {
        public ContentItem()
        {
            StudentProgresses = new HashSet<StudentProgress>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public ContentType Type { get; set; }
        public string Url { get; set; }

        public virtual ICollection<StudentProgress> StudentProgresses { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
