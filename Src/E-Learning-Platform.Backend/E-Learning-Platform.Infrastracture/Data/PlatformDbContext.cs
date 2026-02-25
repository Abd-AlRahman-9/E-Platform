using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Academic;
using WebApplication1.Models.Courseware;
using WebApplication1.Models.Examination;
using WebApplication1.Models.Operations;
using WebApplication1.Models.Users;

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

        // Courseware
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }

        // Examination
        public DbSet<OfficialExam> OfficialExams { get; set; }
        public DbSet<PracticeSession> PracticeSessions { get; set; }
        public DbSet<PracticeSessionLesson> PracticeSessionLessons { get; set; }
        public DbSet<ExamStudentAnswer> ExamStudentAnswers { get; set; }

        // Operations
        public DbSet<InvitationCode> InvitationCodes { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<StudentParentApproval> StudentParentApprovals { get; set; }
        public DbSet<StudentProgress> StudentProgresses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply IEntityTypeConfiguration implementations from this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
