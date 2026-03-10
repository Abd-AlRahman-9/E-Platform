using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class InvitationCodeFakerProfile : IFakerProfile<InvitationCode>
    {
        public Faker<InvitationCode> Build()
        {
            return new Faker<InvitationCode>()
                .RuleFor(ic => ic.Code, f => f.Random.AlphaNumeric(8).ToUpper())
                .RuleFor(ic => ic.TeacherSubjectId, f => f.Random.Int(1, 200))
                .RuleFor(ic => ic.ExpiresAt, f => f.Date.Soon(30))
                .RuleFor(ic => ic.UsageLimit, f => f.Random.Int(1, 100))
                .RuleFor(ic => ic.UsageCount, f => 0)
                .RuleFor(ic => ic.IsActive, f => true)
                .RuleFor(ic => ic.CreatedOn, f => f.Date.Past())
                .RuleFor(ic => ic.UpdatedOn, (f, ic) => f.Random.Bool(0.3f) ? f.Date.Between(ic.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(ic => ic.IsDeleted, f => false);
        }
    }
}
