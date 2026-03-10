using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentParentApprovalFakerProfile : IFakerProfile<StudentParentApproval>
    {
        public Faker<StudentParentApproval> Build()
        {
            return new Faker<StudentParentApproval>()
                .RuleFor(x => x.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(x => x.ParentId, f => f.Random.Int(1, 500))
                .RuleFor(x => x.TeacherSubjectId, f => f.Random.Int(1, 200))
                .RuleFor(x => x.IsApproved, f => f.Random.Bool(0.7f))
                .RuleFor(x => x.ApprovedByUserId, f => f.Random.Bool(0.6f) ? f.Random.Int(1, 1000) : (int?)null)
                .RuleFor(x => x.ApprovedAt, (f, x) => x.IsApproved ? f.Date.Recent(10) : (DateTime?)null)
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.UpdatedOn, (f, x) => f.Random.Bool(0.4f) ? f.Date.Between(x.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(x => x.IsDeleted, f => false);
        }
    }
}
