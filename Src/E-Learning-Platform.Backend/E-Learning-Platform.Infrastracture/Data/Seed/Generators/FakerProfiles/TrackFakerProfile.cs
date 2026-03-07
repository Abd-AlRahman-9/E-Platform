using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class TrackFakerProfile : IFakerProfile<Track>
    {
        public Faker<Track> Build()
        {
            return new Faker<Track>()

               .RuleFor(t => t.Name,
                   f => f.PickRandom(
                       "Science Track",
                       "Mathematics Track",
                       "Languages Track",
                       "Computer Science Track"))

               .RuleFor(t => t.Description,
                   f => f.Lorem.Sentence())

               // BaseEntity
               .RuleFor(t => t.CreatedOn,
                   f => f.Date.Past(2))

               .RuleFor(t => t.UpdatedOn,
                   (f, t) => f.Random.Bool() ? f.Date.Between(t.CreatedOn, DateTime.UtcNow) : null)

               .RuleFor(t => t.IsDeleted,
                   f => false)

               .Ignore(t => t.Subjects);
        }
    }
}
