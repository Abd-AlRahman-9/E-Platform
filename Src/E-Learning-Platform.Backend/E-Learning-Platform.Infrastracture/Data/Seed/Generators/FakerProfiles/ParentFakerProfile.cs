using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class ParentFakerProfile : IFakerProfile<Parent>
    {
        public Faker<Parent> Build()
        {
            throw new NotImplementedException();
        }
    }
}
