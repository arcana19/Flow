using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leave_AspNetUsers_AppUserId",
                table: "Leave");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AspNetUsers_UserId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_UserId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Leave_AppUserId",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Leave");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Leave",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leave_UserId",
                table: "Leave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StaffID",
                table: "AspNetUsers",
                column: "StaffID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Staff_StaffID",
                table: "AspNetUsers",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_AspNetUsers_UserId",
                table: "Leave",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Staff_StaffID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Leave_AspNetUsers_UserId",
                table: "Leave");

            migrationBuilder.DropIndex(
                name: "IX_Leave_UserId",
                table: "Leave");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StaffID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Staff",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Leave",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Leave",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UserId",
                table: "Staff",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_AppUserId",
                table: "Leave",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_AspNetUsers_AppUserId",
                table: "Leave",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_AspNetUsers_UserId",
                table: "Staff",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
