using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Operations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Platform.Core.Entities.Users
{
    [Table("ApplicationUsers", Schema = "Users")]
    public class ApplicationUser : BaseEntity<int>
    {
        public string ProfileImageUrl { get; set; }
        public bool IsActive { get; set; }
        public long NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<QuestionReview> ReviewsMade { get; set; } = new HashSet<QuestionReview>();
    }
}
