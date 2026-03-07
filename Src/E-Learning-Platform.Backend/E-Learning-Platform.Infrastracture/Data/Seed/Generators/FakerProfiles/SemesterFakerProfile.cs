using Bogus;
using E_Learning_Platform.Core.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles
{
    public class SemesterFakerProfile : IFakerProfile<Semester>
    {
        public Faker<Semester> Build()
        {
            throw new NotImplementedException();
        }
    }
}
