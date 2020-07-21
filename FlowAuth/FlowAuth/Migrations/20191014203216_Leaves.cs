using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class Leaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    LeaveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Leave_type = table.Column<int>(nullable: false),
                    Leave_days_taken = table.Column<int>(nullable: false),
                    Leave_startDate = table.Column<DateTime>(nullable: false),
                    Leave_endDate = table.Column<DateTime>(nullable: false),
                    Leave_motivation = table.Column<string>(nullable: true),
                    Leave_status = table.Column<string>(nullable: true),
                    StaffID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.LeaveID);
                    table.ForeignKey(
                        name: "FK_Leave_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leave_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leave_AppUserId",
                table: "Leave",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_StaffID",
                table: "Leave",
                column: "StaffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave");
        }
    }
}
