using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Users
{
    [Table("ApplicationUsers", Schema = "Users")]
    public class ApplicationUser : BaseEntity<int>
    {
        public long NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
