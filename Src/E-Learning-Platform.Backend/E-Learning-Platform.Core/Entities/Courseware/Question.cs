using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Examination;

namespace WebApplication1.Models.Courseware
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

    [Table("Questions", Schema = "Courseware")]
    public class Question : BaseEntity<int>
    {
        public Question()
        {
            StudentAnswers = new HashSet<ExamStudentAnswer>();
        }

        // Use enum as a discriminator in Fluent API (TPH)
        public QuestionType QuestionType { get; set; }
        public string QuestionHeader { get; set; }
        public string RightAnswer { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public virtual ICollection<ExamStudentAnswer> StudentAnswers { get; set; }
    }
}
