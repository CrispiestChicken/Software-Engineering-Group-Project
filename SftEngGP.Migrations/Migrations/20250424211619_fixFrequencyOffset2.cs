using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixFrequencyOffset2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Offset",
                table: "FrequencyOffset",
                newName: "TimeDifference");

            migrationBuilder.AddColumn<int>(
                name: "DateDifference",
                table: "FrequencyOffset",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDifference",
                table: "FrequencyOffset");

            migrationBuilder.RenameColumn(
                name: "TimeDifference",
                table: "FrequencyOffset",
                newName: "Offset");
        }
    }
}
