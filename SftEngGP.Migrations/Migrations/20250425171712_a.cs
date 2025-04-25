using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurand_FrequencyOffset_MeasurmentFrequencyFrequencyId",
                table: "Measurand");

            migrationBuilder.DropIndex(
                name: "IX_Measurand_MeasurmentFrequencyFrequencyId",
                table: "Measurand");

            migrationBuilder.DropColumn(
                name: "MeasurmentFrequencyFrequencyId",
                table: "Measurand");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasurmentFrequencyFrequencyId",
                table: "Measurand",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Measurand_MeasurmentFrequencyFrequencyId",
                table: "Measurand",
                column: "MeasurmentFrequencyFrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurand_FrequencyOffset_MeasurmentFrequencyFrequencyId",
                table: "Measurand",
                column: "MeasurmentFrequencyFrequencyId",
                principalTable: "FrequencyOffset",
                principalColumn: "FrequencyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
