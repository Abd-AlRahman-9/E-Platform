using E_Learning_Platform.Core.Entities.Operations;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Academic
{
    [Table("StudentClassGroups", Schema = "Academic")]
    public class StudentClassGroup :BaseAuditEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassGroupId { get; set; }
        public ClassGroup ClassGroup { get; set; }
        public StudentEnrollmentProcess StudentEnrollmentProcess { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
