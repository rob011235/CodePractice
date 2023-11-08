using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePractice.Migrations
{
    /// <inheritdoc />
    public partial class MakeTitleAndDescriptionOptionalInCompetency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "046eb3d3-e32d-49a1-83e6-a6a5ac77de20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c3e4b63-9b60-497f-81a5-9d3e955a7b5b");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Competencies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competencies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a225ee0-60fb-4ccf-a1c9-d4b9e7004c70", "0ea2f046-9f5f-425b-961c-d48dac158f31", "Admin", "ADMIN" },
                    { "d4775fc1-3ca6-4f9a-9aff-f9a6abddd5ae", "99718b5a-bd0b-4805-93e6-301e09870f40", "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a225ee0-60fb-4ccf-a1c9-d4b9e7004c70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4775fc1-3ca6-4f9a-9aff-f9a6abddd5ae");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Competencies",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competencies",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "046eb3d3-e32d-49a1-83e6-a6a5ac77de20", "24d690f2-f554-469a-a030-c49ae027f8cc", "Admin", "ADMIN" },
                    { "8c3e4b63-9b60-497f-81a5-9d3e955a7b5b", "7777c024-1a5e-420c-a9d3-c7df4a074191", "Instructor", "INSTRUCTOR" }
                });
        }
    }
}
