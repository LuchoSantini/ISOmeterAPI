using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISOmeterAPI.Migrations
{
    public partial class memovedhasdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Status", "Surname", "UserType" },
                values: new object[] { 1, "user@user.com", "user", "password", true, "user", "Admin" });
        }
    }
}
