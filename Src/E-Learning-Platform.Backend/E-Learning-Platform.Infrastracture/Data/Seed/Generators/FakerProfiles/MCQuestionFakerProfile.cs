using Bogus;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class MCQuestionFakerProfile : IFakerProfile<MCQuestion>
    {
        public Faker<MCQuestion> Build()
        {
            return new Faker<MCQuestion>()
                .RuleFor(x => x.CreatedById,
                    f => f.Random.Int(1, 10))

                .RuleFor(x => x.QuestionType,
                    f => QuestionType.MCQ)
                .RuleFor(x => x.QuestionHeader,
                    f => f.Lorem.Sentence())
                .RuleFor(x => x.DifficultyLevel,
                    f => f.PickRandom<DifficultyLevel>())
                .RuleFor(x => x.ApprovalStatus,
                    f => f.PickRandom<QuestionApprovalStatus>())
                .RuleFor(x => x.LessonId,
                    f => f.Random.Int(1, 50))
                .RuleFor(x => x.Options,
                    (f, q) =>
                    {
                        var correctIndex = f.Random.Int(0, 3);

                        var options = new List<QuestionOption>();

                        for (int i = 0; i < 4; i++)
                        {
                            options.Add(new QuestionOption
                            {
                                OptionText = f.Lorem.Word(),
                                IsCorrect = i == correctIndex
                            });
                        }

                        return options;
                    })
                .RuleFor(x => x.RightAnswer,
                    (f, q) => q.Options.First(o => o.IsCorrect).OptionText);
        }
    }
}
