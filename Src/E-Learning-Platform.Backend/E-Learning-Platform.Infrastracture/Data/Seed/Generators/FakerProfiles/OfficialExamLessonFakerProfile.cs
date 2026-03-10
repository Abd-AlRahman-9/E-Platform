using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Examination;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class OfficialExamLessonFakerProfile : IFakerProfile<OfficialExamLesson>
    {
        public Faker<OfficialExamLesson> Build()
        {
            return new Faker<OfficialExamLesson>()
                .RuleFor(x => x.OfficialExamId, f => f.Random.Int(1, 200))
                .RuleFor(x => x.LessonId, f => f.Random.Int(1, 500))
                .RuleFor(x => x.QuestionCount, f => f.Random.Int(0, 50))
                .RuleFor(x => x.Weight, f => (decimal?)Math.Round((decimal)f.Random.Double(0.1, 5.0), 2))
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.UpdatedOn, (f, x) => f.Random.Bool(0.3f) ? f.Date.Between(x.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(x => x.IsDeleted, f => false);
        }
    }
}
