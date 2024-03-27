using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePractice.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseNavigationPropertyToSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ExerciseId",
                table: "Submissions",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Exercises_ExerciseId",
                table: "Submissions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Exercises_ExerciseId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_ExerciseId",
                table: "Submissions");
        }
    }
}
