using System;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Platform.Core.Entities.Users;

namespace E_Learning_Platform.Core.Entities.Operations
{
    public enum PaymentMethod
    {
        Cash,
        Credit,
        BankTransfer,
        MobilePayment,
        Paypal,
        Other,
    }
    [Table("Transactions", Schema = "Operations")]
    public class Transaction : BaseEntity<int>
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ReferenceNumber { get; set; }
        // FK to ApplicationUser.Id (int)
        public int PayerUserId { get; set; }
        public ApplicationUser Payer { get; set; }
        public int TeacherSubjectId { get; set; }
        public int StudentId { get; set; }
        public StudentEnrollmentProcess StudentEnrollment { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
