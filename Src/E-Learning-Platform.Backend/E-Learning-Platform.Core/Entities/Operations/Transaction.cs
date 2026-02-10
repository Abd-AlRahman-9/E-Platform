using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Users;

namespace WebApplication1.Models.Operations
{
    [Table("Transactions", Schema = "Operations")]
    public class Transaction : BaseEntity<int>
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        // FK to ApplicationUser.Id (int)
        public int PayerUserId { get; set; }
        public ApplicationUser Payer { get; set; }

        public int StudentEnrollmentId { get; set; }
        public StudentEnrollment StudentEnrollment { get; set; }

        public string PaymentMethod { get; set; }
    }
}
