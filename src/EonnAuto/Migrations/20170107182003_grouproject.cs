using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EonnAuto.Migrations
{
    public partial class grouproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brake",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Rotor",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Shock",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Tire",
                table: "Inspections");

            migrationBuilder.AddColumn<string>(
                name: "AirFilter",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CabinFilter",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriveBelt",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exhaust",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontBrakes",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontHeadLights",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontRotors",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontSignals",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontSuspension",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontTires",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontWheels",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Horn",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearBrakes",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearRotors",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearStopLights",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearSuspension",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearTires",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearWheels",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Steering",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wipers",
                table: "Inspections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirFilter",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "CabinFilter",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "DriveBelt",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Exhaust",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FrontBrakes",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FrontHeadLights",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FrontRotors",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FrontSignals",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FrontSuspension",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FrontTires",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FrontWheels",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Horn",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "RearBrakes",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "RearRotors",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "RearStopLights",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "RearSuspension",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "RearTires",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "RearWheels",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Steering",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Wipers",
                table: "Inspections");

            migrationBuilder.AddColumn<string>(
                name: "Brake",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rotor",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shock",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tire",
                table: "Inspections",
                nullable: true);
        }
    }
}
