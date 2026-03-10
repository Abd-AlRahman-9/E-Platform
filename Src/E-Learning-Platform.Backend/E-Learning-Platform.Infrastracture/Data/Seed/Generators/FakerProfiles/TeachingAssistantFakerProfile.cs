using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class TeachingAssistantFakerProfile : IFakerProfile<TeachingAssistant>
    {
        public Faker<TeachingAssistant> Build()
        {
            return new Faker<TeachingAssistant>()
                .RuleFor(ta => ta.FirstName, f => f.Name.FirstName())
                .RuleFor(ta => ta.LastName, f => f.Name.LastName())
                .RuleFor(ta => ta.Email, f => f.Internet.Email())
                .RuleFor(ta => ta.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(ta => ta.ProfileImageUrl, f => f.Internet.Avatar())
                .RuleFor(ta => ta.IsActive, f => true)
                .RuleFor(ta => ta.NationalId, f => long.Parse(f.Random.Replace("##########")))
                .RuleFor(ta => ta.CreatedOn, f => f.Date.Past())
                .RuleFor(ta => ta.UpdatedOn, (f, ta) => f.Random.Bool(0.4f) ? f.Date.Between(ta.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(ta => ta.IsDeleted, f => false);
        }
    }
}
