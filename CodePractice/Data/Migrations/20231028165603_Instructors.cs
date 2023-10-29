using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePractice.Data.Migrations
{
    /// <inheritdoc />
    public partial class Instructors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fb6fe03-4baa-426b-8176-ce8a83790101", "a0c4e79a-9aec-4370-9403-0720b0f5657c", "Admin", "ADMIN" },
                    { "effbe27f-8767-4ee8-8037-2164d0a195f5", "b25a5414-0701-4419-ac92-5610e07ac364", "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fb6fe03-4baa-426b-8176-ce8a83790101");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "effbe27f-8767-4ee8-8037-2164d0a195f5");
        }
    }
}
