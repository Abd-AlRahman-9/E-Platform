using System.Collections.Generic;

namespace WebApplication1.Models.Courseware
{
    // MCQuestion is a specialized Question that can have options.
    public class MCQuestion : Question
    {
        public MCQuestion()
        {
            Options = new HashSet<QuestionOption>();
            // Ensure correct discriminator value is set when constructed, but the discriminator
            // is primarily configured by EF Core in OnModelCreating.
            QuestionType = QuestionType.MCQ;
        }

        public virtual ICollection<QuestionOption> Options { get; set; }
    }
}
