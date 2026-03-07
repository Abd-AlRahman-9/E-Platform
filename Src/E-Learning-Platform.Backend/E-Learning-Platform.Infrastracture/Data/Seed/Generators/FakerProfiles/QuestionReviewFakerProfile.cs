using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class QuestionReviewFakerProfile : IFakerProfile<QuestionReview>
    {
        public Faker<QuestionReview> Build()
        {
            return new Faker<QuestionReview>()
                .RuleFor(x => x.ReviewedById,
                    f => f.Random.Int(1, 10))
                .RuleFor(x => x.QuestionId,
                    f => f.Random.Int(1, 100))
                .RuleFor(x => x.ReviewedAt,
                    f => f.Date.Past())
                .RuleFor(x => x.QuestionApprovalStatus,
                    f => f.PickRandom<QuestionApprovalStatus>())
                .RuleFor(x => x.Comment,
                    f => f.Lorem.Sentence());
        }
    }
}
