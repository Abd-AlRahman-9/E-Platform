using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ClassGroupFakerProfile : IFakerProfile<ClassGroup>
    {
        public Faker<ClassGroup> Build()
        {
            return new Faker<ClassGroup>()

                .RuleFor(c => c.Name,
                    f => $"Group {f.Random.Int(1, 20)}")

                .RuleFor(c => c.Capacity,
                    f => f.Random.Int(10, 40))

                .RuleFor(c => c.StartDate,
                    f => f.Date.Past(1))

                .RuleFor(c => c.EndDate,
                    (f, c) => c.StartDate.AddMonths(4))

                .RuleFor(c => c.TeacherSubjectId,
                    f => f.Random.Int(1, 20))

                .RuleFor(c => c.SessionsPerWeek,
                    f => f.Random.Int(1, 3))

                .RuleFor(c => c.SessionsPerMonth,
                    (f, c) => c.SessionsPerWeek * 4)

                // BaseEntity
                .RuleFor(c => c.CreatedOn,
                    f => f.Date.Past(2))

                .RuleFor(c => c.UpdatedOn,
                    (f, c) => f.Random.Bool() ? f.Date.Between(c.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(c => c.IsDeleted,
                    f => false)

                .Ignore(c => c.StudentClassGroups)
                .Ignore(c => c.Sessions)
                .Ignore(c => c.TeacherSubject);
        }
    }
}
