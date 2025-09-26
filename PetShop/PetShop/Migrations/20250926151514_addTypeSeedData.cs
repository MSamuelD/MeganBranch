using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class addTypeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Timeslots_TimeslotId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timeslots",
                table: "Timeslots");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeslotId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Timeslots");

            migrationBuilder.DropColumn(
                name: "TimeslotId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Timeslots",
                newName: "Time");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeslotTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timeslots",
                table: "Timeslots",
                column: "Time");

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Bird" },
                    { 4, "Fish" },
                    { 5, "Reptile" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeslotTime",
                table: "Appointments",
                column: "TimeslotTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Timeslots_TimeslotTime",
                table: "Appointments",
                column: "TimeslotTime",
                principalTable: "Timeslots",
                principalColumn: "Time",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Timeslots_TimeslotTime",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timeslots",
                table: "Timeslots");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeslotTime",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "TimeslotTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Timeslots",
                newName: "StartTime");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Timeslots",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TimeslotId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timeslots",
                table: "Timeslots",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeslotId",
                table: "Appointments",
                column: "TimeslotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Timeslots_TimeslotId",
                table: "Appointments",
                column: "TimeslotId",
                principalTable: "Timeslots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
