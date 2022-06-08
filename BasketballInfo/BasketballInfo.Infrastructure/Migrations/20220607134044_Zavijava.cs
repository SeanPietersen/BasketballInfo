using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballInfo.Infrastructure.Migrations
{
    public partial class Zavijava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "CoachId", "FirstName", "IsQualified", "LastName", "Rank", "TeamId", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "Steve", true, "Kerr", 1, 3, 10 },
                    { 2, "Mike", true, "Brown", 2, 3, 5 },
                    { 3, "Frank", false, "Vogel", 1, 1, 2 },
                    { 4, "Mike", true, "Penberthy", 2, 3, 15 },
                    { 5, "Tyronn", true, "Lue", 1, 2, 15 },
                    { 6, "Jason", false, "Powell", 3, 2, 1 },
                    { 7, "Mike", true, "Penberthy", 2, 3, 15 },
                    { 8, "Kevin", false, "Young", 2, 4, 1 },
                    { 9, "Erik", true, "Spoelstra", 1, 6, 5 },
                    { 10, "Nate", false, "McMillan", 1, 8, 2 },
                    { 11, "Todd", false, "Campbell", 3, 9, 1 },
                    { 12, "Ime", false, "Udoka", 1, 10, 4 },
                    { 13, "Ben", true, "Sullivan", 2, 10, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "CoachId",
                keyValue: 13);
        }
    }
}
