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
            throw new NotImplementedException();
        }
    }
}
