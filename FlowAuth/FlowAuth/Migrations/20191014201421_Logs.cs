using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class Logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Project_Code = table.Column<string>(nullable: false),
                    StaffID = table.Column<int>(nullable: false),
                    Task_DescriptionID = table.Column<int>(nullable: false),
                    Log_date = table.Column<DateTime>(nullable: false),
                    Log_hours = table.Column<double>(nullable: false),
                    TaskDescriptionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_Log_Project_Project_Code",
                        column: x => x.Project_Code,
                        principalTable: "Project",
                        principalColumn: "Project_Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_Tasks_TaskDescriptionID",
                        column: x => x.TaskDescriptionID,
                        principalTable: "Tasks",
                        principalColumn: "TaskDescriptionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_Project_Code",
                table: "Log",
                column: "Project_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Log_StaffID",
                table: "Log",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_TaskDescriptionID",
                table: "Log",
                column: "TaskDescriptionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
