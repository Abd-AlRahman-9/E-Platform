using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Academic
{
    [Table("Semesters", Schema = "Academic")]
    public class Semester : BaseEntity<int>
    {
        public Semester()
        {
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
