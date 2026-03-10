using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class StudentEnrollmentFakerProfile : IFakerProfile<StudentEnrollmentProcess>
    {
        public Faker<StudentEnrollmentProcess> Build()
        {
            return new Faker<StudentEnrollmentProcess>()
                .RuleFor(se => se.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(se => se.TeacherSubjectId, f => f.Random.Int(1, 200))
                .RuleFor(se => se.Status, f => f.PickRandom<EnrollmentStatus>())
                .RuleFor(se => se.PaymentStatus, f => f.PickRandom<PaymentStatus>())
                .RuleFor(se => se.PaidAt, (f, se) => se.PaymentStatus == PaymentStatus.Paid ? f.Date.Recent(10) : (DateTime?)null)
                .RuleFor(se => se.RejectionReason, f => f.Random.Bool(0.1f) ? f.Lorem.Sentence(6) : null)
                .RuleFor(se => se.PaymentDeadline, f => f.Date.Soon(30))
                .RuleFor(se => se.RequestedAt, f => f.Date.Recent(30))
                .RuleFor(se => se.ApprovedAt, (f, se) => se.Status == EnrollmentStatus.Active ? f.Date.Recent(5) : (DateTime?)null)
                .RuleFor(se => se.ApprovedByUserId, f => f.Random.Bool(0.5f) ? f.Random.Int(1, 1000) : (int?)null)
                .RuleFor(se => se.InvitationCodeId, (f, se) => f.Random.Bool(0.2f) ? (int?)f.Random.Int(1, 200) : null)
                .RuleFor(se => se.CreatedOn, f => f.Date.Past())
                .RuleFor(se => se.UpdatedOn, (f, se) => f.Random.Bool(0.4f) ? f.Date.Between(se.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(se => se.IsDeleted, f => false);
        }
    }
}
