using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Operations;

namespace E_Learning_Platform.Core.Entities.Courseware
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
        public int Order {  get; set; }
        public bool IsRequired { get; set; }
        public int EstimatedDurationInMinutes { get; set; }
        public virtual ICollection<StudentProgress> StudentProgresses { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public DateTime? AvailableUntil { get; set; }

    }
}
