using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentAttendanceFakerProfile : IFakerProfile<StudentAttendance>
    {
        public Faker<StudentAttendance> Build()
        {
            return new Faker<StudentAttendance>()
                .RuleFor(sa => sa.AttendanceStatus, f => f.PickRandom<AttendanceStatus>())
                .RuleFor(sa => sa.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(sa => sa.SessionId, f => f.Random.Int(1, 200))
                .RuleFor(sa => sa.RecordedByUserId, f => f.Random.Int(1, 1000))
                .RuleFor(sa => sa.CreatedOn, f => f.Date.Past())
                .RuleFor(sa => sa.UpdatedOn, (f, sa) => f.Random.Bool(0.3f) ? f.Date.Between(sa.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(sa => sa.IsDeleted, f => false);
        }
    }
}
