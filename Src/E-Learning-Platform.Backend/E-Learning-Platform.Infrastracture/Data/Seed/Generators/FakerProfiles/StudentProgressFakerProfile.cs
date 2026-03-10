using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentProgressFakerProfile : IFakerProfile<StudentProgress>
    {
        public Faker<StudentProgress> Build()
        {
            return new Faker<StudentProgress>()
                .RuleFor(sp => sp.ContentItemId, f => f.Random.Int(1, 1000))
                .RuleFor(sp => sp.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(sp => sp.Status, f => f.PickRandom<ProgressStatus>())
                .RuleFor(sp => sp.Interactions, f => f.PickRandom<ContentInteraction>())
                .RuleFor(sp => sp.FirstOpenedAt, f => f.Random.Bool(0.6f) ? f.Date.Recent(30) : (DateTime?)null)
                .RuleFor(sp => sp.CompletedAt, (f, sp) => sp.Status == ProgressStatus.Completed ? f.Date.Between(sp.FirstOpenedAt ?? DateTime.UtcNow.AddDays(-10), DateTime.UtcNow) : (DateTime?)null)
                .RuleFor(sp => sp.TimeSpentSeconds, f => f.Random.Int(0, 3600))
                .RuleFor(sp => sp.Comment, f => f.Random.Bool(0.2f) ? f.Lorem.Sentence(5) : null)
                .RuleFor(sp => sp.TeacherFeedback, f => f.Random.Bool(0.2f) ? f.Lorem.Sentence(6) : null)
                .RuleFor(sp => sp.CreatedOn, f => f.Date.Past())
                .RuleFor(sp => sp.UpdatedOn, (f, sp) => f.Random.Bool(0.4f) ? f.Date.Between(sp.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(sp => sp.IsDeleted, f => false);
        }
    }
}
