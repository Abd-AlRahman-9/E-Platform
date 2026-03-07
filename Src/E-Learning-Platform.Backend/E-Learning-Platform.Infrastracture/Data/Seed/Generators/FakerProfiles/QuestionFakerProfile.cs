using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class QuestionFakerProfile : IFakerProfile<Question>
    {
        public Faker<Question> Build()
        {
            return new Faker<Question>()
                .RuleFor(x => x.CreatedById, f => f.Random.Int(1, 10))
                .RuleFor(x => x.IsImportedByAI, f => f.Random.Bool())
                .RuleFor(x => x.ApprovalStatus,
                    f => f.PickRandom<QuestionApprovalStatus>())
                .RuleFor(x => x.DifficultyLevel,
                    f => f.PickRandom<DifficultyLevel>())
                .RuleFor(x => x.QuestionType,
                    f => QuestionType.Essay)
                .RuleFor(x => x.QuestionHeader,
                    f => f.Lorem.Sentence())
                .RuleFor(x => x.RightAnswer,
                    f => f.Lorem.Word())
                .RuleFor(x => x.LessonId,
                    f => f.Random.Int(1, 50))
                .RuleFor(x => x.ApprovedAt,
                    f => f.Date.Past())
                .RuleFor(x => x.RejectionReason,
                    f => f.Lorem.Sentence())
                .RuleFor(x => x.CreatedOn,
                    f => f.Date.Past());
        }
    }
}
