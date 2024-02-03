using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePractice.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLinkedList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextExerciseId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PreviousExerciseId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "FirstExerciseId",
                table: "Competencies");

            migrationBuilder.DropColumn(
                name: "LastExerciseId",
                table: "Competencies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextExerciseId",
                table: "Exercises",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousExerciseId",
                table: "Exercises",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstExerciseId",
                table: "Competencies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastExerciseId",
                table: "Competencies",
                type: "INTEGER",
                nullable: true);
        }
    }
}
