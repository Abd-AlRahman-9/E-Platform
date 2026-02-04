using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Operations;

namespace WebApplication1.Models.Users
{
    [Table("Parents", Schema = "Users")]
    public class Parent : ApplicationUser
    {
        public Parent()
        {
            Children = new HashSet<StudentParent>();
            ChildApprovals = new HashSet<StudentParentApproval>();
        }

        public virtual ICollection<StudentParent> Children { get; set; }

        // approvals for children (per TeacherSubject)
        public virtual ICollection<StudentParentApproval> ChildApprovals { get; set; }
    }
}
