using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ImportedQuestionBatchFakerProfile : IFakerProfile<ImportedQuestionBatch>
    {
        public Faker<ImportedQuestionBatch> Build()
        {
            return new Faker<ImportedQuestionBatch>()
                .RuleFor(b => b.TeacherSubjectId,
                    f => f.Random.Int(1, 10))
                .RuleFor(b => b.SourceFilePath,
                    f => $"/uploads/questions/{f.Random.Guid()}.png")
                .RuleFor(b => b.TotalExtractedQuestions,
                    f => f.Random.Int(5, 50))
                .RuleFor(b => b.ProcessedByAI,
                    f => f.Random.Bool())
                .RuleFor(b => b.ImportedByUserId,
                    f => f.Random.Int(1, 20))
                .RuleFor(b => b.ImportedAt,
                    f => f.Date.Recent())
                .RuleFor(b => b.CreatedOn, f => f.Date.Past())
                .RuleFor(b => b.UpdatedOn, f => f.Date.Recent())
                .RuleFor(b => b.IsDeleted, f => false);
        }
    }
}
