using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class SemesterFakerProfile : IFakerProfile<Semester>
    {
        public Faker<Semester> Build()
        {
            return new Faker<Semester>()

                .RuleFor(s => s.Name,
                    f => f.PickRandom("First Semester", "Second Semester", "Summer"))

                .RuleFor(s => s.StartDate,
                    f => DateOnly.FromDateTime(f.Date.Past(1)))

                .RuleFor(s => s.EndDate,
                    (f, s) => s.StartDate.AddMonths(4))

                .RuleFor(s => s.AcademicYearId,
                    f => f.Random.Int(1, 10))

                // BaseEntity
                .RuleFor(s => s.CreatedOn,
                    f => f.Date.Past(2))

                .RuleFor(s => s.UpdatedOn,
                    (f, s) => f.Random.Bool(0.5f) ? f.Date.Between(s.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(s => s.IsDeleted,
                    f => false)

                .Ignore(s => s.TeacherSubjects)
                .Ignore(s => s.AcademicYear);
        }
    }
}
