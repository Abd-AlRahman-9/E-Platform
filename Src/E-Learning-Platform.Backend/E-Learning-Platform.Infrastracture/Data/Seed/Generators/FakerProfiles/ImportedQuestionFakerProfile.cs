using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ImportedQuestionFakerProfile : IFakerProfile<ImportedQuestion>
    {
        public Faker<ImportedQuestion> Build()
        {
            return new Faker<ImportedQuestion>()
                .RuleFor(q => q.ImportedQuestionBatchId,
                    f => f.Random.Int(1, 10))
                .RuleFor(q => q.LessonId,
                    f => f.Random.Bool() ? f.Random.Int(1, 20) : null)
                .RuleFor(q => q.ExtractedText, f => f.Lorem.Paragraph())
                .RuleFor(q => q.CandidateOptionsJson, f =>
                {
                    var options = new[]
                    {
                        f.Lorem.Word(),
                        f.Lorem.Word(),
                        f.Lorem.Word(),
                        f.Lorem.Word()
                    };
                    return JsonSerializer.Serialize(options);
                })
                .RuleFor(q => q.CorrectAnswerIndex, f => f.Random.Int(0, 3))
                .RuleFor(q => q.SuggestedDifficulty, f => f.PickRandom<DifficultyLevel>())
                .RuleFor(q => q.SuggestedQuestionType, f => f.PickRandom<QuestionType>())
                .RuleFor(q => q.Status, f => f.PickRandom<ImportedQuestionStatus>())
                .RuleFor(q => q.ReviewedByUserId,
                    f => f.Random.Bool() ? f.Random.Int(1, 20) : null)
                .RuleFor(q => q.ReviewNotes,
                    f => f.Random.Bool() ? f.Lorem.Sentence() : null)
                .RuleFor(q => q.ReviewedAt,
                    f => f.Random.Bool() ? f.Date.Recent() : null)
                .RuleFor(q => q.IsValidated,
                    f => f.Random.Bool())
                .RuleFor(q => q.CreatedOn, f => f.Date.Past())
                .RuleFor(q => q.UpdatedOn, f => f.Date.Recent())
                .RuleFor(q => q.IsDeleted, f => false);
        }
    }
}
