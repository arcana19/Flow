using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class lEAEV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leave_AspNetUsers_UserId",
                table: "Leave");

            migrationBuilder.DropIndex(
                name: "IX_Leave_UserId",
                table: "Leave");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Leave",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leave_AspNetUsers_AppUserId",
                table: "Leave");

            migrationBuilder.DropIndex(
                name: "IX_Leave_AppUserId",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Leave");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_UserId",
                table: "Leave",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_AspNetUsers_UserId",
                table: "Leave",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
