using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentFakerProfile : IFakerProfile<Student>
    {
        public Faker<Student> Build()
        {
            return new Faker<Student>()
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Email, f => f.Internet.Email())
                .RuleFor(s => s.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(s => s.ProfileImageUrl, f => f.Internet.Avatar())
                .RuleFor(s => s.IsActive, f => true)
                .RuleFor(s => s.NationalId, f => long.Parse(f.Random.Replace("##########")))
                .RuleFor(s => s.DateOfBirth, f => f.Date.Past(18))
                .RuleFor(s => s.AcademicYear, f => f.Random.Int(2018, 2026).ToString())
                .RuleFor(s => s.CreatedOn, f => f.Date.Past())
                .RuleFor(s => s.UpdatedOn, (f, s) => f.Random.Bool(0.4f) ? f.Date.Between(s.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(s => s.IsDeleted, f => false);
        }
    }
}
