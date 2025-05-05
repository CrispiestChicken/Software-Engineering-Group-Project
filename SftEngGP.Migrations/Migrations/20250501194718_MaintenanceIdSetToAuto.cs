using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class MaintenanceIdSetToAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallLog",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "MaintenanceType",
                table: "Maintenance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallLog",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceType",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
