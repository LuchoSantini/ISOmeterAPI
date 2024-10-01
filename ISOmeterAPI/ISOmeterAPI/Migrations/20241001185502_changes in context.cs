using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISOmeterAPI.Migrations
{
    public partial class changesincontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Devices_DeviceId",
                table: "Measurement");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Devices_UserId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserId1",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Measurement",
                newName: "Measurements");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_UserId1",
                table: "Room",
                newName: "IX_Room_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_UserId",
                table: "Room",
                newName: "IX_Room_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurement_DeviceId",
                table: "Measurements",
                newName: "IX_Measurements_DeviceId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "Room",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Devices_DeviceId",
                table: "Measurements",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Devices_UserId",
                table: "Room",
                column: "UserId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Users_UserId1",
                table: "Room",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Devices_DeviceId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Devices_UserId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Users_UserId1",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Measurements",
                newName: "Measurement");

            migrationBuilder.RenameIndex(
                name: "IX_Room_UserId1",
                table: "Rooms",
                newName: "IX_Rooms_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Room_UserId",
                table: "Rooms",
                newName: "IX_Rooms_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_DeviceId",
                table: "Measurement",
                newName: "IX_Measurement_DeviceId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "Rooms",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Devices_DeviceId",
                table: "Measurement",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Devices_UserId",
                table: "Rooms",
                column: "UserId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserId1",
                table: "Rooms",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
