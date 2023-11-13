using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePractice.Migrations
{
    /// <inheritdoc />
    public partial class AddCompetencyAsNavProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05a9961d-51fc-45bf-9f10-6726dab09bd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fc0a223-862f-481c-9fa0-f4d317508fcb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4da45dac-f7d8-48c8-b528-03b750b3d3e6", "b021b273-5c1b-4afb-8b96-e39f511cea84", "Admin", "ADMIN" },
                    { "76609e7d-5243-4023-a0c8-ae3662a4c539", "cfd49c95-76c6-47b7-bdcd-4f17035588cb", "Instructor", "INSTRUCTOR" }
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
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "4da45dac-f7d8-48c8-b528-03b750b3d3e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76609e7d-5243-4023-a0c8-ae3662a4c539");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05a9961d-51fc-45bf-9f10-6726dab09bd2", "1ea8e9a9-9d10-42dd-829e-0eb6ff7ec6f7", "Instructor", "INSTRUCTOR" },
                    { "3fc0a223-862f-481c-9fa0-f4d317508fcb", "91677105-6d72-4eda-a56a-212548091bed", "Admin", "ADMIN" }
                });
        }
    }
}
