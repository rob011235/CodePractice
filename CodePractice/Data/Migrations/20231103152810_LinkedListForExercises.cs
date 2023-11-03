using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePractice.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkedListForExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Competencies_CompetencyId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CompetencyId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a5f4b56-7632-42fc-8fe7-0b37058e2b5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7903478-139c-491f-9623-bb8b93d5b072");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "NextExerciseId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousExerciseId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstExerciseId",
                table: "Competencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastExerciseId",
                table: "Competencies",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34e987c9-6bdc-4b3b-adc2-11952300967a", "da13698a-4880-4c90-b234-dd62093088a0", "Instructor", "INSTRUCTOR" },
                    { "d18787f4-0d4a-4f63-93fc-91b1d7ce13ad", "22dcab2e-e083-426e-b07b-2024d64b1864", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34e987c9-6bdc-4b3b-adc2-11952300967a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d18787f4-0d4a-4f63-93fc-91b1d7ce13ad");

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

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a5f4b56-7632-42fc-8fe7-0b37058e2b5e", "fe6a9279-335f-424c-aabb-2eaeb1b3778c", "Admin", "ADMIN" },
                    { "c7903478-139c-491f-9623-bb8b93d5b072", "7608b37e-2fa0-4058-a866-47857b32fb78", "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CompetencyId",
                table: "Exercises",
                column: "CompetencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Competencies_CompetencyId",
                table: "Exercises",
                column: "CompetencyId",
                principalTable: "Competencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
