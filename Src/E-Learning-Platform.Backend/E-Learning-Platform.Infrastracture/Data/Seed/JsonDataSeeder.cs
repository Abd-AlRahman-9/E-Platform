using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Infrastracture.Data.Seed.Generators;
using E_Learning_Platform.Infrastracture.Data.Seed.Generators.FakerProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed
{
    public static class JsonDataSeeder
    {
        public static void GenerateFiles()
        {
            // Academic Schema Json Files

            FakeDataGeneratorEngine.Generate
                (
                    new AcademicYearFakerProfile(),
                    20,
                    SeedPaths.AcademicYear
                );
            FakeDataGeneratorEngine.Generate
                (
                    new SessionFakerProfile(),
                    20,
                    SeedPaths.Session
                );
            FakeDataGeneratorEngine.Generate
                (
                    new SemesterFakerProfile(),
                    20,
                    SeedPaths.Semester
                );
            FakeDataGeneratorEngine.Generate
                (
                    new ClassGroupFakerProfile(),
                    20,
                    SeedPaths.ClassGroup
                );
            FakeDataGeneratorEngine.Generate
                (
                    new StudentClassGroupFakerProfile(),
                    20,
                    SeedPaths.StudentClassGroup
                );
            FakeDataGeneratorEngine.Generate
                (
                    new SubjectFakerProfile(),
                    20,
                    SeedPaths.Subject
                );
            FakeDataGeneratorEngine.Generate
                (
                    new TeacherSubjectFakerProfile(),
                    20,
                    SeedPaths.TeacherSubject
                );
            FakeDataGeneratorEngine.Generate
                (
                    new TrackFakerProfile(),
                    20,
                    SeedPaths.Track
                );

            // Communication Schema Json Files

            // Courseware Schema Json Files

            // Examination Schema Json Files

            // Operation Schema Json Files

            // User Schema Json Files

        }
    }
}
