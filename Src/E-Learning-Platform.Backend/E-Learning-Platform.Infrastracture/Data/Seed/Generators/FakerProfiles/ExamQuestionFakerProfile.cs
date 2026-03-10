using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Examination;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ExamQuestionFakerProfile : IFakerProfile<ExamQuestion>
    {
        public Faker<ExamQuestion> Build()
        {
            return new Faker<ExamQuestion>()
                .RuleFor(x => x.QuestionId, f => f.Random.Int(1, 1000))
                .RuleFor(x => x.OfficialExamId, f => f.Random.Int(1, 200))
                .RuleFor(x => x.Order, f => f.Random.Int(1, 50))
                .RuleFor(x => x.Score, f => Math.Round((decimal)f.Random.Double(0.5, 20.0), 2))
                .RuleFor(x => x.IsMandatory, f => f.Random.Bool(0.2f))
                .RuleFor(x => x.DifficultyOverride, f => f.PickRandom<DifficultyLevel>())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.UpdatedOn, (f, x) => f.Random.Bool(0.5f) ? f.Date.Between(x.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(x => x.IsDeleted, f => false);
        }
    }
}
