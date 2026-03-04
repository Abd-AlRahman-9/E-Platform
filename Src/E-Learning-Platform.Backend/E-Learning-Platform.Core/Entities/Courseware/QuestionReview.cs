using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Learning_Platform.Core.Entities.Courseware
{
    [Table("QuestionReviews", Schema = "Courseware")]
    public class QuestionReview
    {
        public QuestionApprovalStatus QuestionApprovalStatus { get; set; }
        public DateTime ReviewedAt { get; set; }
        public string Comment { get; set; }
        public int ReviewedById { get; set; }
        public ApplicationUser ReviewedBy { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
