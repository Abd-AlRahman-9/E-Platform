using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ConversationParticipantFakerProfile : IFakerProfile<ConversationParticipant>
    {
        public Faker<ConversationParticipant> Build()
        {
            return new Faker<ConversationParticipant>()

                .RuleFor(cp => cp.ConversationId,
                    f => f.Random.Int(1, 20))

                .RuleFor(cp => cp.UserId,
                    f => f.Random.Int(1, 100))

                .RuleFor(cp => cp.IsMuted,
                    f => f.Random.Bool(0.2f))

                .RuleFor(cp => cp.MutedUntil,
                    (f, cp) => cp.IsMuted ? f.Date.Future(1) : null)

                .RuleFor(cp => cp.JoinedAt,
                    f => f.Date.Past(1))

                // BaseAuditEntity
                .RuleFor(cp => cp.CreatedOn,
                    f => f.Date.Past(2))

                .RuleFor(cp => cp.UpdatedOn,
                    (f, cp) => f.Random.Bool() ? f.Date.Between(cp.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(cp => cp.IsDeleted,
                    f => false)

                .Ignore(cp => cp.Conversation)
                .Ignore(cp => cp.User);
        }
    }
}
