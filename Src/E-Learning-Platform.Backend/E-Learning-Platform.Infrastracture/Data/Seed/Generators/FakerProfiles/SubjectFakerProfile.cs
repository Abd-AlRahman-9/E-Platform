using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class SubjectFakerProfile : IFakerProfile<Subject>
    {
        public Faker<Subject> Build()
        {
            return new Faker<Subject>()

                .RuleFor(s => s.Name,
                    f => f.PickRandom(
                        "Mathematics",
                        "Physics",
                        "Chemistry",
                        "Biology",
                        "English",
                        "Computer Science"))

                .RuleFor(s => s.Description,
                    f => f.Lorem.Sentence())

                .RuleFor(s => s.TrackId,
                    f => f.Random.Int(1, 10))

                // BaseEntity
                .RuleFor(s => s.CreatedOn,
                    f => f.Date.Past(2))

                .RuleFor(s => s.UpdatedOn,
                    (f, s) => f.Random.Bool() ? f.Date.Between(s.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(s => s.IsDeleted,
                    f => false)

                .Ignore(s => s.Track)
                .Ignore(s => s.TeacherSubjects);
        }
    }
}
