namespace WebApplication1.Models.Courseware
{
    // TOF inherits from MCQuestion to reuse Options collection.
    public class TOFQuestion : MCQuestion
    {
        public TOFQuestion()
        {
            if (QuestionType != QuestionType.TOF)
                QuestionType = QuestionType.TOF;

            if (Options == null)
            {
                Options = new HashSet<QuestionOption>
                {
                    new QuestionOption { OptionText = "True" },
                    new QuestionOption { OptionText = "False" }
                };
            }
        }
    }
}
