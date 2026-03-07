using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Seed
{
    public class SeedPaths
    {
        public static string BasePath =>
            Path.Combine(Directory.GetCurrentDirectory(), "..\\E-Learning-Platform.Infrastracture\\Data\\Seed\\Json");

        public static string Track =>
            Path.Combine(BasePath, "Tracks.json");

        public static string TeacherSubject =>
            Path.Combine(BasePath, "TeacherSubjects.json");

        public static string Subject =>
            Path.Combine(BasePath, "Subjects.json");

        public static string StudentClassGroup =>
            Path.Combine(BasePath, "StudentClassGroups.json");

        public static string Session =>
            Path.Combine(BasePath, "Sessions.json");

        public static string Semester =>
            Path.Combine(BasePath, "Semesters.json");

        public static string ClassGroup =>
            Path.Combine(BasePath, "ClassGroups.json");

        public static string AcademicYear =>
            Path.Combine(BasePath, "AcademicYears.json");

        public static string Conversations =>
            Path.Combine(BasePath, "Conversations.json");

        public static string ConverstionParticipants =>
            Path.Combine(BasePath, "ConverstionParticipants.json");

        public static string Messages =>
            Path.Combine(BasePath, "Messages.json");

    }
}
