using Microsoft.EntityFrameworkCore;
using E_Learning_Platform.Core.Entities.Academic;
using E_Learning_Platform.Core.Entities.Courseware;
using E_Learning_Platform.Core.Entities.Examination;
using E_Learning_Platform.Core.Entities.Operations;
using E_Learning_Platform.Core.Entities.Users;
using E_Learning_Platform.Core.Entities.Communication;

namespace E_Learning_Platform.Infrastracture.Data
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)
        {
        }

        // Users
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeachingAssistant> TeachingAssistants { get; set; }
        public DbSet<TeacherAssistant> TeacherAssistants { get; set; }

        // Academic
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<StudentClassGroup> StudentClassGroups { get; set; }

        // Courseware
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<MCQuestion> MCQuestions { get; set; }
        public DbSet<TOFQuestion> TOFQuestions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<QuestionReview> QuestionReviews { get; set; }
        public DbSet<ImportedQuestion> ImportedQuestions { get; set; }
        public DbSet<ImportedQuestionBatch> ImportedQuestionBatches { get; set; }

        // Examination
        public DbSet<OfficialExamLesson> OfficialExamLessons { get; set; }
        public DbSet<OfficialExam> OfficialExams { get; set; }
        public DbSet<OfficialExamStudent> OfficialExamStudents { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamStudentAnswer> ExamStudentAnswers { get; set; }
        public DbSet<PracticeSession> PracticeSessions { get; set; }
        public DbSet<PracticeSessionLesson> PracticeSessionLessons { get; set; }
        public DbSet<PracticeSessionStudentAnswer> PracticeSessionStudentAnswers { get; set; }

        // Operations
        public DbSet<InvitationCode> InvitationCodes { get; set; }
        public DbSet<StudentEnrollmentProcess> StudentEnrollments { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<StudentParentApproval> StudentParentApprovals { get; set; }
        public DbSet<StudentProgress> StudentProgresses { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<StudentInvitationCode> StudentInvitationCodes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        // Communication
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationParticipant> ConversationParticipants { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply IEntityTypeConfiguration implementations from this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

