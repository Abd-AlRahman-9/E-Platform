using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning_Platform.Infrastracture.Data.Migrations.Version1
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Academic");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "Courseware");

            migrationBuilder.EnsureSchema(
                name: "Communication");

            migrationBuilder.EnsureSchema(
                name: "Examination");

            migrationBuilder.EnsureSchema(
                name: "Operations");

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NationalId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Academic",
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingAssistants",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingAssistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingAssistants_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalSchema: "Academic",
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PracticeSessions",
                schema: "Examination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswer = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticeSessions_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentParents",
                schema: "Users",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParents", x => new { x.StudentId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Users",
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAssistants",
                schema: "Users",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    AssistantId = table.Column<int>(type: "int", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanApproveStudents = table.Column<bool>(type: "bit", nullable: false),
                    CanApproveParents = table.Column<bool>(type: "bit", nullable: false),
                    CanManageQuestions = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAssistants", x => new { x.TeacherId, x.AssistantId });
                    table.ForeignKey(
                        name: "FK_TeacherAssistants_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Users",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAssistants_TeachingAssistants_AssistantId",
                        column: x => x.AssistantId,
                        principalSchema: "Users",
                        principalTable: "TeachingAssistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "Academic",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Users",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassGroups",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    SessionsPerWeek = table.Column<int>(type: "int", nullable: false),
                    SessionsPerMonth = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassGroups_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportedQuestionBatches",
                schema: "Courseware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    SourceFilePath = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    TotalExtractedQuestions = table.Column<int>(type: "int", nullable: false),
                    ProcessedByAI = table.Column<bool>(type: "bit", nullable: false),
                    ImportedByUserId = table.Column<int>(type: "int", nullable: false),
                    ImportedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportedQuestionBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportedQuestionBatches_ApplicationUsers_ImportedByUserId",
                        column: x => x.ImportedByUserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportedQuestionBatches_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvitationCodes",
                schema: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsageLimit = table.Column<int>(type: "int", nullable: false),
                    UsageCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitationCodes_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                schema: "Courseware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficialExams",
                schema: "Examination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialExams_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentParentApprovals",
                schema: "Operations",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParentApprovals", x => new { x.StudentId, x.ParentId, x.TeacherSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentParentApprovals_ApplicationUsers_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentParentApprovals_Parents_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Users",
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParentApprovals_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParentApprovals_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: true),
                    ClassGroupId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_ClassGroups_ClassGroupId",
                        column: x => x.ClassGroupId,
                        principalSchema: "Academic",
                        principalTable: "ClassGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conversations_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_ClassGroups_ClassGroupId",
                        column: x => x.ClassGroupId,
                        principalSchema: "Academic",
                        principalTable: "ClassGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportedQuestions",
                schema: "Courseware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportedQuestionBatchId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: true),
                    ExtractedText = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CandidateOptionsJson = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CorrectAnswerIndex = table.Column<int>(type: "int", nullable: true),
                    SuggestedDifficulty = table.Column<int>(type: "int", nullable: true),
                    SuggestedQuestionType = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewedByUserId = table.Column<int>(type: "int", nullable: true),
                    ReviewNotes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsValidated = table.Column<bool>(type: "bit", nullable: false, computedColumnSql: "CASE WHEN Status = 'Approved' THEN 1 ELSE 0 END"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportedQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportedQuestions_ApplicationUsers_ReviewedByUserId",
                        column: x => x.ReviewedByUserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImportedQuestions_ImportedQuestionBatches_ImportedQuestionBatchId",
                        column: x => x.ImportedQuestionBatchId,
                        principalSchema: "Courseware",
                        principalTable: "ImportedQuestionBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollmentProcesses",
                schema: "Operations",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    InvitationCodeId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollmentProcesses", x => new { x.StudentId, x.TeacherSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentEnrollmentProcesses_ApplicationUsers_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentEnrollmentProcesses_InvitationCodes_InvitationCodeId",
                        column: x => x.InvitationCodeId,
                        principalSchema: "Operations",
                        principalTable: "InvitationCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentEnrollmentProcesses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrollmentProcesses_TeacherSubjects_TeacherSubjectId",
                        column: x => x.TeacherSubjectId,
                        principalSchema: "Academic",
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentInvitationCodes",
                schema: "Operations",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    InvitationCodeId = table.Column<int>(type: "int", nullable: false),
                    RedeemedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInvitationCodes", x => new { x.StudentId, x.InvitationCodeId });
                    table.ForeignKey(
                        name: "FK_StudentInvitationCodes_InvitationCodes_InvitationCodeId",
                        column: x => x.InvitationCodeId,
                        principalSchema: "Operations",
                        principalTable: "InvitationCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInvitationCodes_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentItems",
                schema: "Courseware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    EstimatedDurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    AvailableUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentItems_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Courseware",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PracticeSessionLessons",
                schema: "Examination",
                columns: table => new
                {
                    PracticeSessionId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    QuestionsAttempted = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeSessionLessons", x => new { x.PracticeSessionId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_PracticeSessionLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Courseware",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracticeSessionLessons_PracticeSessions_PracticeSessionId",
                        column: x => x.PracticeSessionId,
                        principalSchema: "Examination",
                        principalTable: "PracticeSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "Courseware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    ApprovedById = table.Column<int>(type: "int", nullable: true),
                    IsImportedByAI = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionHeader = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    RightAnswer = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_ApplicationUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Courseware",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficialExamLessons",
                columns: table => new
                {
                    OfficialExamId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    QuestionCount = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialExamLessons", x => new { x.OfficialExamId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_OfficialExamLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Courseware",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialExamLessons_OfficialExams_OfficialExamId",
                        column: x => x.OfficialExamId,
                        principalSchema: "Examination",
                        principalTable: "OfficialExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficialExamStudents",
                schema: "Examination",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OfficialExamId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialExamStudents", x => new { x.OfficialExamId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_OfficialExamStudents_OfficialExams_OfficialExamId",
                        column: x => x.OfficialExamId,
                        principalSchema: "Examination",
                        principalTable: "OfficialExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficialExamStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConverstionParticipants",
                schema: "Communication",
                columns: table => new
                {
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsMuted = table.Column<bool>(type: "bit", nullable: false),
                    MutedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConverstionParticipants", x => new { x.ConversationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ConverstionParticipants_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConverstionParticipants_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalSchema: "Communication",
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "Communication",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_ApplicationUsers_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalSchema: "Communication",
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                schema: "Operations",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttendances", x => new { x.StudentId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_StudentAttendances_ApplicationUsers_RecordedByUserId",
                        column: x => x.RecordedByUserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "Academic",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassGroups",
                schema: "Academic",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassGroupId = table.Column<int>(type: "int", nullable: false),
                    StudentEnrollmentProcessStudentId = table.Column<int>(type: "int", nullable: false),
                    StudentEnrollmentProcessTeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassGroups", x => new { x.StudentId, x.ClassGroupId });
                    table.ForeignKey(
                        name: "FK_StudentClassGroups_ClassGroups_ClassGroupId",
                        column: x => x.ClassGroupId,
                        principalSchema: "Academic",
                        principalTable: "ClassGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassGroups_StudentEnrollmentProcesses_StudentEnrollmentProcessStudentId_StudentEnrollmentProcessTeacherSubjectId",
                        columns: x => new { x.StudentEnrollmentProcessStudentId, x.StudentEnrollmentProcessTeacherSubjectId },
                        principalSchema: "Operations",
                        principalTable: "StudentEnrollmentProcesses",
                        principalColumns: new[] { "StudentId", "TeacherSubjectId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassGroups_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayerUserId = table.Column<int>(type: "int", nullable: false),
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_ApplicationUsers_PayerUserId",
                        column: x => x.PayerUserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_StudentEnrollmentProcesses_StudentId_TeacherSubjectId",
                        columns: x => new { x.StudentId, x.TeacherSubjectId },
                        principalSchema: "Operations",
                        principalTable: "StudentEnrollmentProcesses",
                        principalColumns: new[] { "StudentId", "TeacherSubjectId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentProgresses",
                schema: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentItemId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interactions = table.Column<int>(type: "int", nullable: false),
                    FirstOpenedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSpentSeconds = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProgresses_ContentItems_ContentItemId",
                        column: x => x.ContentItemId,
                        principalSchema: "Courseware",
                        principalTable: "ContentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProgresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                schema: "Examination",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OfficialExamId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyOverride = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => new { x.QuestionId, x.OfficialExamId });
                    table.ForeignKey(
                        name: "FK_ExamQuestions_OfficialExams_OfficialExamId",
                        column: x => x.OfficialExamId,
                        principalSchema: "Examination",
                        principalTable: "OfficialExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Courseware",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamStudentAnswers",
                schema: "Examination",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OfficialExamId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStudentAnswers", x => new { x.StudentId, x.QuestionId, x.OfficialExamId });
                    table.ForeignKey(
                        name: "FK_ExamStudentAnswers_OfficialExams_OfficialExamId",
                        column: x => x.OfficialExamId,
                        principalSchema: "Examination",
                        principalTable: "OfficialExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamStudentAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Courseware",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamStudentAnswers_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PracticeSessionStudentAnswers",
                schema: "Examination",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    PracticeSessionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeSessionStudentAnswers", x => new { x.StudentId, x.QuestionId, x.PracticeSessionId });
                    table.ForeignKey(
                        name: "FK_PracticeSessionStudentAnswers_PracticeSessions_PracticeSessionId",
                        column: x => x.PracticeSessionId,
                        principalSchema: "Examination",
                        principalTable: "PracticeSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracticeSessionStudentAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Courseware",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracticeSessionStudentAnswers_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Users",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                schema: "Courseware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MCQuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_MCQuestionId",
                        column: x => x.MCQuestionId,
                        principalSchema: "Courseware",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionReviews",
                schema: "Courseware",
                columns: table => new
                {
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedById = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionReviews", x => new { x.QuestionId, x.ReviewedById, x.ReviewedAt });
                    table.ForeignKey(
                        name: "FK_QuestionReviews_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionReviews_ApplicationUsers_ReviewedById",
                        column: x => x.ReviewedById,
                        principalSchema: "Users",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionReviews_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Courseware",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_IsActive",
                schema: "Academic",
                table: "AcademicYears",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_Name",
                schema: "Academic",
                table: "AcademicYears",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Email",
                schema: "Users",
                table: "ApplicationUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_NationalId",
                schema: "Users",
                table: "ApplicationUsers",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassGroups_TeacherSubjectId",
                schema: "Academic",
                table: "ClassGroups",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentItems_LessonId",
                schema: "Courseware",
                table: "ContentItems",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ClassGroupId",
                schema: "Communication",
                table: "Conversations",
                column: "ClassGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_TeacherSubjectId",
                schema: "Communication",
                table: "Conversations",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConverstionParticipants_ConversationId",
                schema: "Communication",
                table: "ConverstionParticipants",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConverstionParticipants_UserId",
                schema: "Communication",
                table: "ConverstionParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_OfficialExamId",
                schema: "Examination",
                table: "ExamQuestions",
                column: "OfficialExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_QuestionId",
                schema: "Examination",
                table: "ExamQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStudentAnswers_OfficialExamId",
                schema: "Examination",
                table: "ExamStudentAnswers",
                column: "OfficialExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStudentAnswers_QuestionId",
                schema: "Examination",
                table: "ExamStudentAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportedQuestionBatches_ImportedByUserId",
                schema: "Courseware",
                table: "ImportedQuestionBatches",
                column: "ImportedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportedQuestionBatches_TeacherSubjectId",
                schema: "Courseware",
                table: "ImportedQuestionBatches",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportedQuestions_ImportedQuestionBatchId",
                schema: "Courseware",
                table: "ImportedQuestions",
                column: "ImportedQuestionBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportedQuestions_ReviewedByUserId",
                schema: "Courseware",
                table: "ImportedQuestions",
                column: "ReviewedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationCodes_Code",
                schema: "Operations",
                table: "InvitationCodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvitationCodes_TeacherSubjectId",
                schema: "Operations",
                table: "InvitationCodes",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherSubjectId",
                schema: "Courseware",
                table: "Lessons",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                schema: "Communication",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                schema: "Communication",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialExamLessons_LessonId",
                table: "OfficialExamLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialExams_TeacherSubjectId",
                schema: "Examination",
                table: "OfficialExams",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialExamStudents_OfficialExamId",
                schema: "Examination",
                table: "OfficialExamStudents",
                column: "OfficialExamId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialExamStudents_StudentId",
                schema: "Examination",
                table: "OfficialExamStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSessionLessons_LessonId",
                schema: "Examination",
                table: "PracticeSessionLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSessions_StudentId",
                schema: "Examination",
                table: "PracticeSessions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSessionStudentAnswers_PracticeSessionId",
                schema: "Examination",
                table: "PracticeSessionStudentAnswers",
                column: "PracticeSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSessionStudentAnswers_QuestionId",
                schema: "Examination",
                table: "PracticeSessionStudentAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_MCQuestionId",
                schema: "Courseware",
                table: "QuestionOptions",
                column: "MCQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionReviews_ApplicationUserId",
                schema: "Courseware",
                table: "QuestionReviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionReviews_QuestionId",
                schema: "Courseware",
                table: "QuestionReviews",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionReviews_ReviewedById",
                schema: "Courseware",
                table: "QuestionReviews",
                column: "ReviewedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ApprovedById",
                schema: "Courseware",
                table: "Questions",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedById",
                schema: "Courseware",
                table: "Questions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LessonId",
                schema: "Courseware",
                table: "Questions",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_AcademicYearId_Name",
                schema: "Academic",
                table: "Semesters",
                columns: new[] { "AcademicYearId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClassGroupId",
                schema: "Academic",
                table: "Sessions",
                column: "ClassGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_RecordedByUserId",
                schema: "Operations",
                table: "StudentAttendances",
                column: "RecordedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_SessionId",
                schema: "Operations",
                table: "StudentAttendances",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassGroups_ClassGroupId",
                schema: "Academic",
                table: "StudentClassGroups",
                column: "ClassGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassGroups_StudentEnrollmentProcessStudentId_StudentEnrollmentProcessTeacherSubjectId",
                schema: "Academic",
                table: "StudentClassGroups",
                columns: new[] { "StudentEnrollmentProcessStudentId", "StudentEnrollmentProcessTeacherSubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassGroups_StudentId",
                schema: "Academic",
                table: "StudentClassGroups",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollmentProcesses_ApprovedByUserId",
                schema: "Operations",
                table: "StudentEnrollmentProcesses",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollmentProcesses_InvitationCodeId",
                schema: "Operations",
                table: "StudentEnrollmentProcesses",
                column: "InvitationCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollmentProcesses_Status",
                schema: "Operations",
                table: "StudentEnrollmentProcesses",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollmentProcesses_TeacherSubjectId",
                schema: "Operations",
                table: "StudentEnrollmentProcesses",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInvitationCodes_InvitationCodeId",
                schema: "Operations",
                table: "StudentInvitationCodes",
                column: "InvitationCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInvitationCodes_StudentId",
                schema: "Operations",
                table: "StudentInvitationCodes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentApprovals_ApprovedByUserId",
                schema: "Operations",
                table: "StudentParentApprovals",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentApprovals_ParentId",
                schema: "Operations",
                table: "StudentParentApprovals",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentApprovals_TeacherSubjectId",
                schema: "Operations",
                table: "StudentParentApprovals",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_ParentId",
                schema: "Users",
                table: "StudentParents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresses_ContentItemId",
                schema: "Operations",
                table: "StudentProgresses",
                column: "ContentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresses_StudentId_ContentItemId",
                schema: "Operations",
                table: "StudentProgresses",
                columns: new[] { "StudentId", "ContentItemId" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TrackId",
                schema: "Academic",
                table: "Subjects",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssistants_AssistantId",
                schema: "Users",
                table: "TeacherAssistants",
                column: "AssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SemesterId",
                schema: "Academic",
                table: "TeacherSubjects",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId",
                schema: "Academic",
                table: "TeacherSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_TeacherId",
                schema: "Academic",
                table: "TeacherSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PayerUserId",
                schema: "Operations",
                table: "Transactions",
                column: "PayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StudentId_TeacherSubjectId",
                schema: "Operations",
                table: "Transactions",
                columns: new[] { "StudentId", "TeacherSubjectId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConverstionParticipants",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "ExamQuestions",
                schema: "Examination");

            migrationBuilder.DropTable(
                name: "ExamStudentAnswers",
                schema: "Examination");

            migrationBuilder.DropTable(
                name: "ImportedQuestions",
                schema: "Courseware");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "OfficialExamLessons");

            migrationBuilder.DropTable(
                name: "OfficialExamStudents",
                schema: "Examination");

            migrationBuilder.DropTable(
                name: "PracticeSessionLessons",
                schema: "Examination");

            migrationBuilder.DropTable(
                name: "PracticeSessionStudentAnswers",
                schema: "Examination");

            migrationBuilder.DropTable(
                name: "QuestionOptions",
                schema: "Courseware");

            migrationBuilder.DropTable(
                name: "QuestionReviews",
                schema: "Courseware");

            migrationBuilder.DropTable(
                name: "StudentAttendances",
                schema: "Operations");

            migrationBuilder.DropTable(
                name: "StudentClassGroups",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "StudentInvitationCodes",
                schema: "Operations");

            migrationBuilder.DropTable(
                name: "StudentParentApprovals",
                schema: "Operations");

            migrationBuilder.DropTable(
                name: "StudentParents",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "StudentProgresses",
                schema: "Operations");

            migrationBuilder.DropTable(
                name: "TeacherAssistants",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Operations");

            migrationBuilder.DropTable(
                name: "ImportedQuestionBatches",
                schema: "Courseware");

            migrationBuilder.DropTable(
                name: "Conversations",
                schema: "Communication");

            migrationBuilder.DropTable(
                name: "OfficialExams",
                schema: "Examination");

            migrationBuilder.DropTable(
                name: "PracticeSessions",
                schema: "Examination");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "Courseware");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Parents",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "ContentItems",
                schema: "Courseware");

            migrationBuilder.DropTable(
                name: "TeachingAssistants",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "StudentEnrollmentProcesses",
                schema: "Operations");

            migrationBuilder.DropTable(
                name: "ClassGroups",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Lessons",
                schema: "Courseware");

            migrationBuilder.DropTable(
                name: "InvitationCodes",
                schema: "Operations");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "TeacherSubjects",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Semesters",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "AcademicYears",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Tracks",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "ApplicationUsers",
                schema: "Users");
        }
    }
}
