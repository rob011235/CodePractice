using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePractice.Migrations
{
    /// <inheritdoc />
    public partial class UserNameAddedToSubmissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d9bfbcb-0d4f-4bc4-9324-65ab397d37a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "624e0ebd-bc40-4bd9-8e8e-a08becb553ab");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Submissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05a9961d-51fc-45bf-9f10-6726dab09bd2", "1ea8e9a9-9d10-42dd-829e-0eb6ff7ec6f7", "Instructor", "INSTRUCTOR" },
                    { "3fc0a223-862f-481c-9fa0-f4d317508fcb", "91677105-6d72-4eda-a56a-212548091bed", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05a9961d-51fc-45bf-9f10-6726dab09bd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fc0a223-862f-481c-9fa0-f4d317508fcb");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Submissions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d9bfbcb-0d4f-4bc4-9324-65ab397d37a1", "074ed4c2-0ae2-4ce4-890e-35ef49011266", "Instructor", "INSTRUCTOR" },
                    { "624e0ebd-bc40-4bd9-8e8e-a08becb553ab", "8bc73761-e088-4be9-a78b-0470ee4558fe", "Admin", "ADMIN" }
                });
        }
    }
}
