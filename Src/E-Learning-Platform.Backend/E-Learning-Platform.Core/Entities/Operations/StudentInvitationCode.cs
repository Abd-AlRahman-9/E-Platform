using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Operations
{
    [Table("StudentInvitationCodes", Schema = "Operations")]
    public class StudentInvitationCode : BaseAuditEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int InvitationCodeId { get; set; }
        public InvitationCode InvitationCode { get; set; }

        public DateTime RedeemedAt { get; set; } = DateTime.UtcNow;
    }
}
