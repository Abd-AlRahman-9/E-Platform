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
                .RuleFor(a => a.Name, f =>
                {
                    var startYear = f.Date.Past(5).Year;
                    var endYear = startYear + 1;
                    return $"{startYear}-{endYear}";
                })
                .RuleFor(a => a.StartDate, f =>
                {
                    var year = f.Date.Past(5).Year;
                    return new DateTime(year, 9, 1);
                })
                .RuleFor(a => a.EndDate, (f, a) =>
                {
                    return a.StartDate.AddMonths(10);
                })
                .RuleFor(a => a.IsActive, f => f.Random.Bool(0.3f));
        }
    }
}
