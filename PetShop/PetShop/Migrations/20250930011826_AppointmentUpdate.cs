using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Timeslots_TimeslotTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Timeslots");

            migrationBuilder.RenameColumn(
                name: "TimeslotTime",
                table: "Appointments",
                newName: "SessionDate");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_TimeslotTime",
                table: "Appointments",
                newName: "IX_Appointments_SessionDate");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTimeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Date);
                    table.ForeignKey(
                        name: "FK_Sessions_Timeslots_EndTimeTime",
                        column: x => x.EndTimeTime,
                        principalTable: "Timeslots",
                        principalColumn: "Time",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Timeslots_StartTimeTime",
                        column: x => x.StartTimeTime,
                        principalTable: "Timeslots",
                        principalColumn: "Time",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_EndTimeTime",
                table: "Sessions",
                column: "EndTimeTime");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_StartTimeTime",
                table: "Sessions",
                column: "StartTimeTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Sessions_SessionDate",
                table: "Appointments",
                column: "SessionDate",
                principalTable: "Sessions",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Sessions_SessionDate",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Sessions");

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

            migrationBuilder.RenameColumn(
                name: "SessionDate",
                table: "Appointments",
                newName: "TimeslotTime");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_SessionDate",
                table: "Appointments",
                newName: "IX_Appointments_TimeslotTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Timeslots",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
