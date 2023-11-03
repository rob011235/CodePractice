using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePractice.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fb6fe03-4baa-426b-8176-ce8a83790101");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "effbe27f-8767-4ee8-8037-2164d0a195f5");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fb6fe03-4baa-426b-8176-ce8a83790101", "a0c4e79a-9aec-4370-9403-0720b0f5657c", "Admin", "ADMIN" },
                    { "effbe27f-8767-4ee8-8037-2164d0a195f5", "b25a5414-0701-4419-ac92-5610e07ac364", "Instructor", "INSTRUCTOR" }
                });
        }
    }
}
