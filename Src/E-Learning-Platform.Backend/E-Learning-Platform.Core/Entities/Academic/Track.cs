using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Academic
{
    [Table("Tracks", Schema = "Academic")]
    public class Track : BaseEntity<int>
    {
        public Track()
        {
            Subjects = new HashSet<Subject>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
