using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Academic
{
    [Table("Subjects", Schema = "Academic")]
    public class Subject : BaseEntity<int>
    {
        public Subject()
        {
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
