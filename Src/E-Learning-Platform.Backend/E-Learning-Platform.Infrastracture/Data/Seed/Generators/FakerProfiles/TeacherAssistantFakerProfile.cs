using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class TeacherAssistantFakerProfile : IFakerProfile<TeacherAssistant>
    {
        public Faker<TeacherAssistant> Build()
        {
            return new Faker<TeacherAssistant>()
                .RuleFor(ta => ta.TeacherId, f => f.Random.Int(1, 200))
                .RuleFor(ta => ta.AssistantId, f => f.Random.Int(1, 500))
                .RuleFor(ta => ta.JoinedAt, f => f.Date.Past())
                .RuleFor(ta => ta.CanApproveStudents, f => f.Random.Bool(0.5f))
                .RuleFor(ta => ta.CanApproveParents, f => f.Random.Bool(0.3f))
                .RuleFor(ta => ta.CanManageQuestions, f => f.Random.Bool(0.4f))
                .RuleFor(ta => ta.CreatedOn, f => f.Date.Past())
                .RuleFor(ta => ta.UpdatedOn, (f, ta) => f.Random.Bool(0.4f) ? f.Date.Between(ta.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(ta => ta.IsDeleted, f => false);
        }
    }
}
