using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EonnAuto.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_Vehicle_VehicleId",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_AspNetUsers_UserId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inspection",
                table: "Inspection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inspections",
                table: "Inspection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Vehicles_VehicleId",
                table: "Inspection",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicle",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_UserId",
                table: "Vehicle",
                newName: "IX_Vehicles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inspection_VehicleId",
                table: "Inspection",
                newName: "IX_Inspections_VehicleId");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Inspection",
                newName: "Inspections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Vehicles_VehicleId",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inspections",
                table: "Inspections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inspection",
                table: "Inspections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_Vehicle_VehicleId",
                table: "Inspections",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_AspNetUsers_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                newName: "IX_Vehicle_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inspections_VehicleId",
                table: "Inspections",
                newName: "IX_Inspection_VehicleId");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Inspections",
                newName: "Inspection");
        }
    }
}
