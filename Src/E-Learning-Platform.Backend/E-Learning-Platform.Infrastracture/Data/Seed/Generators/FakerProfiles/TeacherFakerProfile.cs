using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class TeacherFakerProfile : IFakerProfile<Teacher>
    {
        public Faker<Teacher> Build()
        {
            throw new NotImplementedException();
        }
    }
}
 