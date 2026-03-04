using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Platform.Core.Entities.Academic
{
    [Table("ClassGroups", Schema = "Academic")]
    public class ClassGroup : BaseEntity<int>
    {
        public ClassGroup() 
        {
            StudentClassGroups = new HashSet<StudentClassGroup>();
            Sessions = new HashSet<Session>();
        }
        public string Name { get; set; } 
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TeacherSubjectId {  get; set; }
        public TeacherSubject TeacherSubject { get; set; }
        public virtual ICollection<StudentClassGroup> StudentClassGroups { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public int SessionsPerWeek { get; set; }
        public int SessionsPerMonth { get; set; }
    }
}
