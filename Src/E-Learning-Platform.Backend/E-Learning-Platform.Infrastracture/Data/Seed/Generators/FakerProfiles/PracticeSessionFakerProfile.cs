using Bogus;
using E_Learning_Platform.Core.Entities.Examination;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class PracticeSessionFakerProfile : IFakerProfile<PracticeSession>
    {
        public Faker<PracticeSession> Build()
        {
            return new Faker<PracticeSession>()
                .RuleFor(p => p.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.TotalQuestions, f => f.Random.Int(5, 50))
                .RuleFor(p => p.CorrectAnswer, (f, p) => f.Random.Int(0, p.TotalQuestions))
                .RuleFor(p => p.Score, (f, p) => Math.Round((decimal)f.Random.Double(0, 100), 2))
                .RuleFor(p => p.StartedAt, f => f.Date.Recent())
                .RuleFor(p => p.EndedAt, (f, p) => p.StartedAt.AddMinutes(f.Random.Int(5, 120)))
                .RuleFor(p => p.CreatedOn, f => f.Date.Past())
                .RuleFor(p => p.UpdatedOn, (f, p) => f.Random.Bool(0.4f) ? f.Date.Between(p.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(p => p.IsDeleted, f => false);
        }
    }
}
