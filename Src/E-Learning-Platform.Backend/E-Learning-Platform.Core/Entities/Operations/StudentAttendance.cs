using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Operations
{
    public enum AttendanceStatus
    {
        Absent = 0,
        Execused,
        Late,
        Present,
    }
    [Table("StudentAttendances", Schema = "Operations")]
    public class StudentAttendance : BaseAuditEntity
    {
        public AttendanceStatus AttendanceStatus { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int RecordedByUserId { get; set; }
        public ApplicationUser RecordedByUser { get; set; }
    }
}
