using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Examination;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class PracticeSessionLessonFakerProfile : IFakerProfile<PracticeSessionLesson>
    {
        public Faker<PracticeSessionLesson> Build()
        {
            return new Faker<PracticeSessionLesson>()
                .RuleFor(x => x.PracticeSessionId, f => f.Random.Int(1, 1000))
                .RuleFor(x => x.LessonId, f => f.Random.Int(1, 500))
                .RuleFor(x => x.Score, f => Math.Round((decimal)f.Random.Double(0, 100), 2))
                .RuleFor(x => x.QuestionsAttempted, f => f.Random.Int(0, 50))
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.UpdatedOn, (f, x) => f.Random.Bool(0.4f) ? f.Date.Between(x.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(x => x.IsDeleted, f => false);
        }
    }
}
