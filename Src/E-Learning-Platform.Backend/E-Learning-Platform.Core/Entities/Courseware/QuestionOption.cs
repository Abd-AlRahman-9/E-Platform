using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Courseware
{
    [Table("QuestionOptions", Schema = "Courseware")]
    public class QuestionOption : BaseEntity<int>
    {
        // FK pointing to Questions(Id). EF mapping will constrain this options
        // relationship only to MCQuestion (and thus TOF which inherits MCQuestion)
        public int MCQuestionId { get; set; }
        public MCQuestion MCQuestion { get; set; }

        public string OptionText { get; set; }
    }
}
