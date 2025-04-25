using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixFrequencyOffset3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Measurand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Measurand");
        }
    }
}
