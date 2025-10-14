using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Bookings", "City", "Country", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "State", "StreetName", "StreetNumber", "ZipCode" },
                values: new object[] { 2, "[]", "", "", new DateOnly(1990, 1, 1), "", "John", "Doe", "1234", "", "", "", "", 2000 });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "City", "Country", "DateOfBirth", "Discriminator", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "State", "StreetName", "StreetNumber", "ZipCode" },
                values: new object[] { 3, "Syd", "Aus", new DateOnly(2025, 2, 2), "Staff", "email", "Staffy", "McStaff", "password", "123", "NSW", "Street", "123", 2000 });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "CustomerId", "Name", "TypeId" },
                values: new object[,]
                {
                    { 1, 2, "Buddy", 1 },
                    { 2, 2, "Mittens", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
