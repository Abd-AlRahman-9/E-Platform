using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class AcademicYearFakerProfile : IFakerProfile<AcademicYear>
    {
        public Faker<AcademicYear> Build()
        {
            return new Faker<AcademicYear>()

                // Academic Data
                .RuleFor(a => a.Name, f =>
                {
                    var startYear = f.Random.Int(2020, 2026);
                    return $"{startYear}-{startYear + 1}";
                })

                .RuleFor(a => a.StartDate, (f, a) =>
                {
                    var startYear = int.Parse(a.Name.Split('-')[0]);
                    return new DateTime(startYear, 9, 1);
                })

                .RuleFor(a => a.EndDate, (f, a) =>
                    a.StartDate.AddMonths(10))

                .RuleFor(a => a.IsActive, f => f.Random.Bool(0.3f))

                // BaseEntity Fields
                .RuleFor(a => a.CreatedOn,
                    f => f.Date.Past(2))

                .RuleFor(a => a.UpdatedOn,
                    (f, a) => f.Random.Bool(0.5f) ? f.Date.Between(a.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(a => a.IsDeleted,
                    f => false)

                // Ignore Navigation Property
                .Ignore(a => a.Semesters);
        }
    }
}
