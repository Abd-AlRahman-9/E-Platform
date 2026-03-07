using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class QuestionOptionFakerProfile : IFakerProfile<QuestionOption>
    {
        public Faker<QuestionOption> Build()
        {
            return new Faker<QuestionOption>()
                .RuleFor(x => x.OptionText,
                    f => f.Lorem.Word())
                .RuleFor(x => x.IsCorrect,
                    f => f.Random.Bool());
        }
    }
}
