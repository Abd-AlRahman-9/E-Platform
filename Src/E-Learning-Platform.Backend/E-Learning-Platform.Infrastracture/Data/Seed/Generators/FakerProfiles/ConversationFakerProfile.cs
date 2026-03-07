using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ConversationFakerProfile : IFakerProfile<Conversation>
    {
        public Faker<Conversation> Build()
        {
            return new Faker<Conversation>()

                .RuleFor(c => c.ConversationType,
                    f => f.PickRandom<ConversationType>())

                .RuleFor(c => c.TeacherSubjectId,
                    f => f.Random.Bool(0.6f) ? f.Random.Int(1, 20) : null)

                .RuleFor(c => c.ClassGroupId,
                    f => f.Random.Bool(0.5f) ? f.Random.Int(1, 20) : null)

                // BaseEntity
                .RuleFor(c => c.CreatedOn,
                    f => f.Date.Past(1))

                .RuleFor(c => c.UpdatedOn,
                    (f, c) => f.Random.Bool() ? f.Date.Between(c.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(c => c.IsDeleted,
                    f => false)

                .Ignore(c => c.TeacherSubject)
                .Ignore(c => c.ClassGroup)
                .Ignore(c => c.ConversationParticipants)
                .Ignore(c => c.Messages);
        }
    }
}
