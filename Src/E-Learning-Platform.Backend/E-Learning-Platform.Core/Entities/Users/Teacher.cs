using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Academic;

namespace E_Learning_Platform.Core.Entities.Users
{
    [Table("Teachers", Schema = "Users")]
    public class Teacher : ApplicationUser
    {
        public Teacher()
        {
            Assistants = new HashSet<TeacherAssistant>();
            Subjects = new HashSet<TeacherSubject>();
        }

        // Use ICollection for EF Core navigation properties
        public virtual ICollection<TeacherAssistant> Assistants { get; set; }
        public virtual ICollection<TeacherSubject> Subjects { get; set; }

        // Prefer DateTimeOffset for timestamps; set a sensible default or mark [Required]
        public DateTimeOffset JoinDate { get; set; } = DateTimeOffset.UtcNow;
    }
}
