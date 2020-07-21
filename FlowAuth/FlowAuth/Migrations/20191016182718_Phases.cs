using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class Phases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhaseNames",
                columns: table => new
                {
                    PhaseNameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phase_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseNames", x => x.PhaseNameID);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    PhaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhaseNameID = table.Column<int>(nullable: false),
                    Project_Code = table.Column<string>(nullable: false),
                    Phase_startDate = table.Column<DateTime>(nullable: false),
                    Phase_endDate = table.Column<DateTime>(nullable: false),
                    Phase_budget = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.PhaseID);
                    table.ForeignKey(
                        name: "FK_Phases_PhaseNames_PhaseNameID",
                        column: x => x.PhaseNameID,
                        principalTable: "PhaseNames",
                        principalColumn: "PhaseNameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phases_Project_Project_Code",
                        column: x => x.Project_Code,
                        principalTable: "Project",
                        principalColumn: "Project_Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phases_PhaseNameID",
                table: "Phases",
                column: "PhaseNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_Project_Code",
                table: "Phases",
                column: "Project_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "PhaseNames");
        }
    }
}
