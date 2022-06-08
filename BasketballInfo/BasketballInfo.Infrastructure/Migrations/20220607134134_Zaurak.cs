using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballInfo.Infrastructure.Migrations
{
    public partial class Zaurak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "seanpietersen7@gmail.com", "Sean", "Pietersen", "Sean2563" },
                    { 2, "jase.pietersen7@gmail.com", "Jason", "Pietersen", "Jason2563" },
                    { 3, "pfpietersen@gmail.com", "Percival", "Pietersen", "Percy50" },
                    { 4, "cmpietersen7@gmail.com", "Claudia", "Pietersen", "Claudia2563" },
                    { 5, "rumerkerm@gmail.com", "Rumer", "Manis", "Rumer1234" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);
        }
    }
}
