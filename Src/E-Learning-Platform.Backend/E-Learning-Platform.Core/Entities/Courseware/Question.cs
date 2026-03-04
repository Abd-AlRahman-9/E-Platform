using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using E_Learning_Platform.Core.Entities.Examination;
using E_Learning_Platform.Core.Entities.Users;

namespace E_Learning_Platform.Core.Entities.Courseware
{
    public enum QuestionType
    {
        TOF = 1,
        MCQ,
        Essay,
        FillInTheBlanks,
        ShortAnswer,
        ExplainWhy,
        MultipleResponse,
        FileUpload,
        Coding,
        AudioResponse,
        VideoResponse,
    }
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard,
    }
    public enum QuestionApprovalStatus
    {
        Draft,
        PendingApproval,
        Approved,
        Rejected,
        NeedsRevision
    }
    [Table("Questions", Schema = "Courseware")]
    public class Question : BaseEntity<int>
    {
        public Question()
        {
            Reviews = new HashSet<QuestionReview>();
            ExamStudentAnswers = new HashSet<ExamStudentAnswer>();
            PracticeSessionStudentAnswers = new HashSet<PracticeSessionStudentAnswer>();
        }
        public int CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public int? ApprovedById { get; set; }
        public ApplicationUser ApprovedBy { get; set; }
        public bool IsImportedByAI { get; set; }
        public string RejectionReason { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public QuestionApprovalStatus ApprovalStatus { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        // Use enum as a discriminator in Fluent API (TPH)
        public QuestionType QuestionType { get; set; }
        public string QuestionHeader { get; set; }
        public string RightAnswer { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public virtual ICollection<QuestionReview> Reviews { get; set; }
        public virtual ICollection<ExamStudentAnswer> ExamStudentAnswers { get; set; }
        public virtual ICollection<PracticeSessionStudentAnswer> PracticeSessionStudentAnswers { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
