using System;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Users;

namespace E_Learning_Platform.Core.Entities.Operations
{
    public enum ProgressStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
    [Flags]
    public enum ContentInteraction
    {
        None = 0,
        Seen = 1,
        Opened = 2,
        Commented = 4,
        FeedbackGiven = 8,
        Downloaded = 16,
        Replayed = 32
    }
    [Table("StudentProgresses", Schema = "Operations")]
    public class StudentProgress : BaseEntity<int>
    {
        public int ContentItemId { get; set; }
        public ContentItem ContentItem { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public ProgressStatus Status { get; set; }

        public ContentInteraction Interactions { get; set; }

        public DateTime? FirstOpenedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public int TimeSpentSeconds { get; set; }

        public string Comment { get; set; }
        public string TeacherFeedback { get; set; }
    }
}
