using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePractice.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameToTitleInCompetency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Competencies",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Competencies",
                newName: "Name");
        }
    }
}
