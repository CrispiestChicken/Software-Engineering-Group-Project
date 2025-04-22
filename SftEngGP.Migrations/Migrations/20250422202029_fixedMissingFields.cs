using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SftEngGP.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixedMissingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IncidenceId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfLastUpdate",
                table: "Update",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdateType",
                table: "Update",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Sensor",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Sensor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SensorType",
                table: "Sensor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeasurmentFrequency",
                table: "Measurand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Measurand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuantityType",
                table: "Measurand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SensorId",
                table: "Measurand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Measurand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Measurand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Alert",
                table: "Incidence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfEvent",
                table: "Incidence",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "IncidenceType",
                table: "Incidence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "MaxThreshold",
                table: "Configuration",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinThreshold",
                table: "Configuration",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ReadingFormat",
                table: "Configuration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReadingInterval",
                table: "Configuration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "Configuration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IncidenceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfLastUpdate",
                table: "Update");

            migrationBuilder.DropColumn(
                name: "UpdateType",
                table: "Update");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "SensorType",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "MeasurmentFrequency",
                table: "Measurand");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Measurand");

            migrationBuilder.DropColumn(
                name: "QuantityType",
                table: "Measurand");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Measurand");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Measurand");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Measurand");

            migrationBuilder.DropColumn(
                name: "Alert",
                table: "Incidence");

            migrationBuilder.DropColumn(
                name: "DateOfEvent",
                table: "Incidence");

            migrationBuilder.DropColumn(
                name: "IncidenceType",
                table: "Incidence");

            migrationBuilder.DropColumn(
                name: "MaxThreshold",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "MinThreshold",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "ReadingFormat",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "ReadingInterval",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Configuration");
        }
    }
}
