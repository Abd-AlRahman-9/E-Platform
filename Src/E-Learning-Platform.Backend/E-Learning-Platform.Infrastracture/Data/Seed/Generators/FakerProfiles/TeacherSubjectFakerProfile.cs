using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class TeacherSubjectFakerProfile : IFakerProfile<TeacherSubject>
    {
        public Faker<TeacherSubject> Build()
        {
            return new Faker<TeacherSubject>()

                .RuleFor(ts => ts.TeacherId,
                    f => f.Random.Int(1, 20))

                .RuleFor(ts => ts.SemesterId,
                    f => f.Random.Int(1, 10))

                .RuleFor(ts => ts.SubjectId,
                    f => f.Random.Int(1, 20))

                .RuleFor(ts => ts.Description,
                    f => f.Lorem.Sentence())

                // BaseEntity
                .RuleFor(ts => ts.CreatedOn,
                    f => f.Date.Past(2))

                .RuleFor(ts => ts.UpdatedOn,
                    (f, ts) => f.Random.Bool() ? f.Date.Between(ts.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(ts => ts.IsDeleted,
                    f => false)

                .Ignore(ts => ts.Teacher)
                .Ignore(ts => ts.Subject)
                .Ignore(ts => ts.Semester)
                .Ignore(ts => ts.ClassGroups)
                .Ignore(ts => ts.ImportedQuestionBatches)
                .Ignore(ts => ts.Lessons)
                .Ignore(ts => ts.OfficialExams)
                .Ignore(ts => ts.InvitationCodes)
                .Ignore(ts => ts.Enrollments)
                .Ignore(ts => ts.ParentApprovals);
        }
    }
}
