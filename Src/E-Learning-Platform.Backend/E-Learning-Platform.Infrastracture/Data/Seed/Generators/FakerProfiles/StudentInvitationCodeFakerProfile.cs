using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentInvitationCodeFakerProfile : IFakerProfile<StudentInvitationCode>
    {
        public Faker<StudentInvitationCode> Build()
        {
            return new Faker<StudentInvitationCode>()
                .RuleFor(x => x.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(x => x.InvitationCodeId, f => f.Random.Int(1, 200))
                .RuleFor(x => x.RedeemedAt, f => f.Date.Recent(30))
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.UpdatedOn, (f, x) => f.Random.Bool(0.3f) ? f.Date.Between(x.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(x => x.IsDeleted, f => false);
        }
    }
}
