using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballInfo.Infrastructure.Migrations
{
    public partial class Zibal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "DateOfBirth", "FirstName", "LastName", "PlayerHeight", "PlayerWeight", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephan", "Curry", 1.8899999999999999, 83.900000000000006, 3 },
                    { 2, new DateTime(1984, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebron", "James", 2.1000000000000001, 113.40000000000001, 1 },
                    { 3, new DateTime(1991, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kawhi", "Leonard", 2.04, 102.09999999999999, 2 },
                    { 4, new DateTime(1996, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Devin", "Booker", 1.98, 93.400000000000006, 4 },
                    { 5, new DateTime(1995, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikola", "Jokic", 2.2000000000000002, 128.80000000000001, 5 },
                    { 6, new DateTime(1989, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jimmy", "Butler", 2.04, 104.3, 6 },
                    { 7, new DateTime(1994, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gary", "Harris", 1.95, 95.299999999999997, 7 },
                    { 8, new DateTime(1998, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trey", "Young", 1.8600000000000001, 74.400000000000006, 8 },
                    { 9, new DateTime(1997, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lonzo", "Ball", 2.0099999999999998, 86.200000000000003, 9 },
                    { 10, new DateTime(1998, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jayson", "Tatum", 2.0699999999999998, 95.299999999999997, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 10);
        }
    }
}
