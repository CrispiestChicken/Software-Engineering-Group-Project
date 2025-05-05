using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class dataimport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Air_quality",
                schema: "dbo",
                columns: table => new
                {
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    NitrogenDioxide = table.Column<float>(type: "real", nullable: false),
                    SulphurDioxide = table.Column<float>(type: "real", nullable: false),
                    PM25 = table.Column<float>(type: "real", nullable: false),
                    PM10 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Air_quality", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "Water_quality",
                schema: "dbo",
                columns: table => new
                {
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Nitrate = table.Column<float>(type: "real", nullable: false),
                    Nitrite = table.Column<float>(type: "real", nullable: false),
                    Phosphate = table.Column<float>(type: "real", nullable: false),
                    EC = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water_quality", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                schema: "dbo",
                columns: table => new
                {
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    temperature = table.Column<float>(type: "real", nullable: false),
                    relative_humidity = table.Column<byte>(type: "tinyint", nullable: false),
                    wind_speed = table.Column<float>(type: "real", nullable: false),
                    wind_direction = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.datetime);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Air_quality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Water_quality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Weather",
                schema: "dbo");
        }
    }
}
