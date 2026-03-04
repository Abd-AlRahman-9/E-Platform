using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Courseware
{
    public enum ImportedQuestionStatus
    {
        Pending,      // مستخرج ولم يُراجع
        Approved,     // تمت الموافقة وتحويله لسؤال رسمي
        Rejected,     // مرفوض
        NeedsEdit     // يحتاج تعديل قبل الاعتماد
    }

    [Table("ImportedQuestions", Schema = "Courseware")]
    public class ImportedQuestion : BaseEntity<int>
    {
        public int ImportedQuestionBatchId { get; set; }
        public ImportedQuestionBatch Batch { get; set; }

        // يمكن تحديد الدرس لاحقاً أو تلقائياً
        public int? LessonId { get; set; }

        // النص المستخرج من الصورة
        public string ExtractedText { get; set; }

        // الخيارات المقترحة (JSON)
        public string CandidateOptionsJson { get; set; }

        // رقم الإجابة الصحيحة المقترحة
        public int? CorrectAnswerIndex { get; set; }

        // مستوى الصعوبة المقترح من AI
        public DifficultyLevel? SuggestedDifficulty { get; set; }

        // نوع السؤال المقترح
        public QuestionType? SuggestedQuestionType { get; set; }

        public ImportedQuestionStatus Status { get; set; } = ImportedQuestionStatus.Pending;

        // مراجعة بشرية
        public int? ReviewedByUserId { get; set; }
        public ApplicationUser ReviewedByUser { get; set; }

        public string ReviewNotes { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public bool IsValidated {  get; set; }
    }
}
