using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Examination;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ExamStudentAnswerFakerProfile : IFakerProfile<ExamStudentAnswer>
    {
        public Faker<ExamStudentAnswer> Build()
        {
            return new Faker<ExamStudentAnswer>()
                .RuleFor(x => x.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(x => x.QuestionId, f => f.Random.Int(1, 1000))
                .RuleFor(x => x.OfficialExamId, f => f.Random.Int(1, 200))
                .RuleFor(x => x.IsCorrect, f => f.Random.Bool(0.5f))
                .RuleFor(x => x.AnswerText, f => f.Lorem.Sentence(1, 10))
                .RuleFor(x => x.SubmittedAt, f => f.Date.Recent())
                .RuleFor(x => x.Score, f => (decimal?)Math.Round((decimal)f.Random.Double(0, 20), 2))
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.UpdatedOn, (f, x) => f.Random.Bool(0.4f) ? f.Date.Between(x.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(x => x.IsDeleted, f => false);
        }
    }
}
