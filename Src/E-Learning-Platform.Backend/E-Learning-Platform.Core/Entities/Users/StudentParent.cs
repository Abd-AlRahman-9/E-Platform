using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Users
{
    public enum RelationshipType
    {
        Father = 1,
        Mother = 2,
        Brother = 3,
        Sister = 4,
        Guardian = 5,
        Other = 99
    }

    [Table("StudentParents", Schema = "Users")]
    public class StudentParent : BaseAuditEntity
    {
        // Composite key (StudentId, ParentId) configured in DbContext
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public RelationshipType Relationship { get; set; }
    }
}
