using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Examination;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class OfficialExamFakerProfile : IFakerProfile<OfficialExam>
    {
        public Faker<OfficialExam> Build()
        {
            return new Faker<OfficialExam>()
                .RuleFor(e => e.TargetType, f => f.PickRandom<ExamTargetType>())
                .RuleFor(e => e.Title, f => f.Lorem.Sentence(3))
                .RuleFor(e => e.StartedAt, f => f.Date.Soon())
                .RuleFor(e => e.DurationInMinutes, f => f.Random.Int(30, 180))
                .RuleFor(e => e.EndAt, (f, e) => e.StartedAt.AddMinutes(e.DurationInMinutes))
                .RuleFor(e => e.TeacherSubjectId, f => f.Random.Int(1, 20))
                .RuleFor(e => e.CreatedOn, f => f.Date.Past())
                .RuleFor(e => e.UpdatedOn, (f, e) => f.Random.Bool(0.5f) ? f.Date.Between(e.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(e => e.IsDeleted, f => false);
        }
    }
}
