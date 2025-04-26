using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFrequencyOffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrequencyOffset",
                columns: table => new
                {
                    FrequencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Offset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequencyOffset", x => x.FrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "Measurand",
                columns: table => new
                {
                    MeasurandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurmentFrequencyFrequencyId = table.Column<int>(type: "int", nullable: false),
                    SensorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurand", x => x.MeasurandId);
                    table.ForeignKey(
                        name: "FK_Measurand_FrequencyOffset_MeasurmentFrequencyFrequencyId",
                        column: x => x.MeasurmentFrequencyFrequencyId,
                        principalTable: "FrequencyOffset",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurand_MeasurmentFrequencyFrequencyId",
                table: "Measurand",
                column: "MeasurmentFrequencyFrequencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurand");

            migrationBuilder.DropTable(
                name: "FrequencyOffset");
        }
    }
}
