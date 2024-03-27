using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePractice.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCodePracticeRepos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FirstExerciseId = table.Column<int>(type: "INTEGER", nullable: true),
                    LastExerciseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsCorrect = table.Column<bool>(type: "INTEGER", nullable: true),
                    StudentComments = table.Column<string>(type: "TEXT", nullable: true),
                    InstructorComments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    DesiredOutput = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: false),
                    Hint = table.Column<string>(type: "TEXT", nullable: false),
                    CompetencyId = table.Column<int>(type: "INTEGER", nullable: true),
                    PreviousExerciseId = table.Column<int>(type: "INTEGER", nullable: true),
                    NextExerciseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Competencies_CompetencyId",
                        column: x => x.CompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    StorageName = table.Column<string>(type: "TEXT", nullable: true),
                    SubmissionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileSubmissions_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CompetencyId",
                table: "Exercises",
                column: "CompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FileSubmissions_SubmissionId",
                table: "FileSubmissions",
                column: "SubmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "FileSubmissions");

            migrationBuilder.DropTable(
                name: "Competencies");

            migrationBuilder.DropTable(
                name: "Submissions");
        }
    }
}
