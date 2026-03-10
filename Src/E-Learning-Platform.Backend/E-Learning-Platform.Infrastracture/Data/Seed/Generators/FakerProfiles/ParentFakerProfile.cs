using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ParentFakerProfile : IFakerProfile<Parent>
    {
        public Faker<Parent> Build()
        {
            return new Faker<Parent>()
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.ProfileImageUrl, f => f.Internet.Avatar())
                .RuleFor(p => p.IsActive, f => true)
                .RuleFor(p => p.NationalId, f => long.Parse(f.Random.Replace("##########")))
                .RuleFor(p => p.CreatedOn, f => f.Date.Past())
                .RuleFor(p => p.UpdatedOn, (f, p) => f.Random.Bool(0.4f) ? f.Date.Between(p.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(p => p.IsDeleted, f => false);
        }
    }
}
