using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Platform.Core.Entities.Users
{
    [Table("TeachingAssistants", Schema = "Users")]
    public class TeachingAssistant : ApplicationUser
    {
        public TeachingAssistant()
        {
            AssignedTeachers = new HashSet<TeacherAssistant>();
        }

        public virtual ICollection<TeacherAssistant> AssignedTeachers { get; set; }
    }
}
