using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class TransactionFakerProfile : IFakerProfile<Transaction>
    {
        public Faker<Transaction> Build()
        {
            return new Faker<Transaction>()
                .RuleFor(t => t.Amount, f => Math.Round((decimal)f.Finance.Amount(5, 1000), 2))
                .RuleFor(t => t.TransactionDate, f => f.Date.Recent(30))
                .RuleFor(t => t.ReferenceNumber, f => f.Random.AlphaNumeric(12))
                .RuleFor(t => t.PayerUserId, f => f.Random.Int(1, 1000))
                .RuleFor(t => t.TeacherSubjectId, f => f.Random.Int(1, 200))
                .RuleFor(t => t.StudentId, f => f.Random.Int(1, 1000))
                .RuleFor(t => t.PaymentMethod, f => f.PickRandom<PaymentMethod>())
                .RuleFor(t => t.CreatedOn, f => f.Date.Past())
                .RuleFor(t => t.UpdatedOn, (f, t) => f.Random.Bool(0.5f) ? f.Date.Between(t.CreatedOn, DateTime.UtcNow) : null)
                .RuleFor(t => t.IsDeleted, f => false);
        }
    }
}
