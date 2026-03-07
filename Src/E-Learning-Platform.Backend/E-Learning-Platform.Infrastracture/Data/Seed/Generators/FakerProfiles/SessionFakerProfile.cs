using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class SessionFakerProfile : IFakerProfile<Session>
    {
        public Faker<Session> Build()
        {
            return new Faker<Session>()

               .RuleFor(s => s.Status,
                   f => f.PickRandom<SessionStatus>())

               .RuleFor(s => s.Description,
                   f => f.Lorem.Sentence())

               .RuleFor(s => s.SessionDate,
                   f => f.Date.Recent(30))

               .RuleFor(s => s.StartTime,
                   (f, s) => s.SessionDate.AddHours(f.Random.Int(8, 16)))

               .RuleFor(s => s.EndTime,
                   (f, s) => s.StartTime.AddHours(1))

               .RuleFor(s => s.ClassGroupId,
                   f => f.Random.Int(1, 20))

               // BaseEntity
               .RuleFor(s => s.CreatedOn,
                   f => f.Date.Past(2))

               .RuleFor(s => s.UpdatedOn,
                   (f, s) => f.Random.Bool() ? f.Date.Between(s.CreatedOn, DateTime.UtcNow) : null)

               .RuleFor(s => s.IsDeleted,
                   f => false)

               .Ignore(s => s.StudentAttendances)
               .Ignore(s => s.ClassGroup);
        }
    }
}
