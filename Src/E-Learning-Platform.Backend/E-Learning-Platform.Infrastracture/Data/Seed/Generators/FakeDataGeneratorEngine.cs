using E_Learning_Platform.Infrastracture.Data.Seed.Writers;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed.Generators
{
    public class FakeDataGeneratorEngine
    {
        public static void Generate<T>(IFakerProfile<T> profile, int count, string path) where T : class
        {
            var faker = profile.Build();
            
            var data = faker.Generate(count);
            
            JsonFileWriter.WriteFile(path,data);
        }
    }
}
