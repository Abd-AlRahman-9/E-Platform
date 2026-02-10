using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Academic
{
    [Table("AcademicYears", Schema = "Academic")]
    public class AcademicYear : BaseEntity<int>
    {
        public AcademicYear()
        {
            Semesters = new HashSet<Semester>();
        }

        public string Name { get; set; } // "2025-2026"
        public bool IsActive { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
