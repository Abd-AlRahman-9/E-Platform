using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class TeacherFakerProfile : IFakerProfile<Teacher>
    {
        public Faker<Teacher> Build()
        {
            return new Faker<Teacher>()
                .RuleFor(t => t.FirstName, f => f.Name.FirstName())
                .RuleFor(t => t.LastName, f => f.Name.LastName())
                .RuleFor(t => t.Email, f => f.Internet.Email())
                .RuleFor(t => t.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(t => t.ProfileImageUrl, f => f.Internet.Avatar())
                .RuleFor(t => t.IsActive, f => true)
                .RuleFor(t => t.NationalId, f => long.Parse(f.Random.Replace("##########")))
                .RuleFor(t => t.JoinDate, f => f.Date.PastOffset())
                .RuleFor(t => t.CreatedOn, f => f.Date.Past())
                .RuleFor(t => t.UpdatedOn, (f, t) => f.Random.Bool(0.4f) ? f.Date.Between(t.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(t => t.IsDeleted, f => false);
        }
    }
}
 