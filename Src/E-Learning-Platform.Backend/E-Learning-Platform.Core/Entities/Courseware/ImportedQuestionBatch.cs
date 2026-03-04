using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Courseware
{
    [Table("ImportedQuestionBatches", Schema = "Courseware")]
    public class ImportedQuestionBatch : BaseEntity<int>
    {
        public ImportedQuestionBatch()
        {
            ImportedQuestions = new HashSet<ImportedQuestion>();
        }

        // المادة التي ينتمي لها الاستيراد
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }

        // مسار الصورة أو الملف المرفوع
        public string SourceFilePath { get; set; }
        public int TotalExtractedQuestions { get; set; }
        // هل تم استخدام OCR أو AI
        public bool ProcessedByAI { get; set; }

        // من قام بالاستيراد
        public int ImportedByUserId { get; set; }
        public ApplicationUser ImportedByUser { get; set; }

        public DateTime ImportedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ImportedQuestion> ImportedQuestions { get; set; }
    }
}
