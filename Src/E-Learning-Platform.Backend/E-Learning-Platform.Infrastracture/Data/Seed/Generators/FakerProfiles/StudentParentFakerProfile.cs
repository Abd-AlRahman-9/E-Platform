using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentParentFakerProfile : IFakerProfile<StudentParent>
    {
        public Faker<StudentParent> Build()
        {
            return new Faker<StudentParent>()
                .RuleFor(sp => sp.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(sp => sp.ParentId, f => f.Random.Int(1, 500))
                .RuleFor(sp => sp.Relationship, f => f.PickRandom<RelationshipType>())
                .RuleFor(sp => sp.CreatedOn, f => f.Date.Past())
                .RuleFor(sp => sp.UpdatedOn, (f, sp) => f.Random.Bool(0.4f) ? f.Date.Between(sp.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(sp => sp.IsDeleted, f => false);
        }
    }
}
