using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class SensorIDInIncidence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "Incidence",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Incidence");
        }
    }
}
