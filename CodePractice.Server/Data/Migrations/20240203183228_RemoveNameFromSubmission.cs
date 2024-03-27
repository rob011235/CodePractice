using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePractice.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNameFromSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Submissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Submissions",
                type: "TEXT",
                nullable: true);
        }
    }
}
