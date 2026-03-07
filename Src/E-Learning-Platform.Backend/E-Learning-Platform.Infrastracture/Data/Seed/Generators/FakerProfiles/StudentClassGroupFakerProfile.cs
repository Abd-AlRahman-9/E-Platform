using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentClassGroupFakerProfile : IFakerProfile<StudentClassGroup>
    {
        public Faker<StudentClassGroup> Build()
        {
            return new Faker<StudentClassGroup>()

                .RuleFor(scg => scg.StudentId,
                    f => f.Random.Int(1, 100))

                .RuleFor(scg => scg.ClassGroupId,
                    f => f.Random.Int(1, 20))

                .RuleFor(scg => scg.JoinedAt,
                    f => f.Date.Past(1))

                // BaseAuditEntity
                .RuleFor(scg => scg.CreatedOn,
                    f => f.Date.Past(2))

                .RuleFor(scg => scg.UpdatedOn,
                    (f, scg) => f.Random.Bool() ? f.Date.Between(scg.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(scg => scg.IsDeleted,
                    f => false)

                .Ignore(scg => scg.Student)
                .Ignore(scg => scg.ClassGroup)
                .Ignore(scg => scg.StudentEnrollmentProcess);
        }
    }
}
