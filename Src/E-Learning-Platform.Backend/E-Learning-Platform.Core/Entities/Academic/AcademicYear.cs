using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Platform.Core.Entities.Academic
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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
