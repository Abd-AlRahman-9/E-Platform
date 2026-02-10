using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Courseware;
using WebApplication1.Models.Users;

namespace WebApplication1.Models.Operations
{
    [Table("StudentProgresses", Schema = "Operations")]
    public class StudentProgress : BaseEntity<int>
    {
        public int ContentItemId { get; set; }
        public ContentItem ContentItem { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
