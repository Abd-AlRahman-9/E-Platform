using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Academic
{
    public enum SessionStatus
    {
        Canceled = 0,
        Postponed,
        Done,
    }
    [Table("Sessions", Schema = "Academic")]
    public class Session : BaseEntity<int>
    {
        public Session ()
        {
            StudentAttendances = new HashSet<StudentAttendance> ();
        }
        public SessionStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime SessionDate { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<StudentAttendance> StudentAttendances { get; set; }
        public int ClassGroupId { get; set; }
        public ClassGroup ClassGroup { get; set; }
    }
}
