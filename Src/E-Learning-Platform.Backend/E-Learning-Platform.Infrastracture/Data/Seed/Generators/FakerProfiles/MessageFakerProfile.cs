using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class MessageFakerProfile : IFakerProfile<Message>
    {
        public Faker<Message> Build()
        {
            return new Faker<Message>()

                .RuleFor(m => m.MessageType,
                    f => f.PickRandom<MessageType>())

                .RuleFor(m => m.Content,
                    f => f.Lorem.Sentence(10))

                .RuleFor(m => m.SentIn,
                    f => f.Date.Recent(10))

                .RuleFor(m => m.ArrivedAt,
                    (f, m) => m.SentIn.AddSeconds(f.Random.Int(1, 30)))

                .RuleFor(m => m.IsEdited,
                    f => f.Random.Bool(0.15f))

                .RuleFor(m => m.EditedAt,
                    (f, m) => m.IsEdited ? m.SentIn.AddMinutes(f.Random.Int(1, 60)) : null)

                .RuleFor(m => m.SenderId,
                    f => f.Random.Int(1, 50))

                .RuleFor(m => m.ConversationId,
                    f => f.Random.Int(1, 20))

                // BaseEntity
                .RuleFor(m => m.CreatedOn,
                    f => f.Date.Past(1))

                .RuleFor(m => m.UpdatedOn,
                    (f, m) => f.Random.Bool() ? f.Date.Between(m.CreatedOn, DateTime.UtcNow) : null)

                .RuleFor(m => m.IsDeleted,
                    f => false)

                .Ignore(m => m.Sender)
                .Ignore(m => m.Conversation);
        }
    }
}
