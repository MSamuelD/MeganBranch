using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentSchemaUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Pets_PetId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Timeslots_TimeslotTime",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PetId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Timeslots");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "TimeslotTime",
                table: "Appointments",
                newName: "StartTimeTime");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_TimeslotTime",
                table: "Appointments",
                newName: "IX_Appointments_StartTimeTime");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Appointments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "PetName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Timeslots",
                column: "Time",
                values: new object[]
                {
                    new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 9, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 11, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Timeslots_StartTimeTime",
                table: "Appointments",
                column: "StartTimeTime",
                principalTable: "Timeslots",
                principalColumn: "Time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Timeslots_StartTimeTime",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 9, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 11, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DeleteData(
                table: "Timeslots",
                keyColumn: "Time",
                keyValue: new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PetName",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "StartTimeTime",
                table: "Appointments",
                newName: "TimeslotTime");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_StartTimeTime",
                table: "Appointments",
                newName: "IX_Appointments_TimeslotTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Timeslots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PetId",
                table: "Appointments",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Pets_PetId",
                table: "Appointments",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Timeslots_TimeslotTime",
                table: "Appointments",
                column: "TimeslotTime",
                principalTable: "Timeslots",
                principalColumn: "Time",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
