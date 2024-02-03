using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePractice.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderToExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Exercises");
        }
    }
}
