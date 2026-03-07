using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class LessonFakerProfile : IFakerProfile<Lesson>
    {
        public Faker<Lesson> Build()
        {
            return new Faker<Lesson>()
                .RuleFor(l => l.Title, f => f.Lorem.Sentence(3))
                .RuleFor(l => l.Location, f => f.Internet.Url())
                .RuleFor(l => l.Order, f => f.Random.Int(1, 20))
                .RuleFor(l => l.TeacherSubjectId, f => f.Random.Int(1, 10))
                .RuleFor(l => l.CreatedOn, f => f.Date.Past())
                .RuleFor(l => l.UpdatedOn, f => f.Date.Recent())
                .RuleFor(l => l.IsDeleted, f => false);
        }
    }
}
