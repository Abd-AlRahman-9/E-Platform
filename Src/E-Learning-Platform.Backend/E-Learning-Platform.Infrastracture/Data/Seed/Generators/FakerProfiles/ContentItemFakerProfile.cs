using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ContentItemFakerProfile : IFakerProfile<ContentItem>
    {
        public Faker<ContentItem> Build()
        {
            return new Faker<ContentItem>().
                RuleFor(c => c.Title, f => f.Lorem.Sentence(4))
                .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                .RuleFor(c => c.Type, f => f.PickRandom<ContentType>())
                .RuleFor(c => c.Url, f => f.Internet.Url())
                .RuleFor(c => c.Order, f => f.Random.Int(1, 10))
                .RuleFor(c => c.IsRequired, f => f.Random.Bool())
                .RuleFor(c => c.EstimatedDurationInMinutes,
                    f => f.Random.Int(5, 120))
                .RuleFor(c => c.LessonId, f => f.Random.Int(1, 20))
                .RuleFor(c => c.AvailableUntil,
                    f => f.Date.Future())
                .RuleFor(c => c.CreatedOn, f => f.Date.Past())
                .RuleFor(c => c.UpdatedOn, f => f.Date.Recent())
                .RuleFor(c => c.IsDeleted, f => false);
        }
    }
}
