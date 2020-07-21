using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class SomeFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Client_name = table.Column<string>(nullable: false),
                    Client_service = table.Column<string>(nullable: false),
                    Company_regNo = table.Column<string>(nullable: true),
                    Client_work_address = table.Column<string>(nullable: true),
                    Client_workNo = table.Column<int>(nullable: false),
                    Client_DOB = table.Column<DateTime>(nullable: false),
                    Client_id_no = table.Column<long>(nullable: false),
                    Client_contactName = table.Column<string>(nullable: false),
                    Client_contactEmail = table.Column<string>(nullable: false),
                    Client_contactNo = table.Column<long>(nullable: false),
                    Account_status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Supplier_name = table.Column<string>(nullable: false),
                    Supplier_services = table.Column<string>(nullable: false),
                    Supplier_reg_no = table.Column<string>(nullable: false),
                    Supplier_bank_name = table.Column<string>(nullable: false),
                    Supplier_bank_accNumber = table.Column<string>(nullable: false),
                    Supplier_bank_accType = table.Column<string>(nullable: false),
                    Supplier_bank_branch = table.Column<string>(nullable: false),
                    Supplier_vatNo = table.Column<double>(nullable: false),
                    Supplier_address = table.Column<string>(nullable: false),
                    Supplier_contactName = table.Column<string>(nullable: false),
                    Supplier_contactNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Project_Code = table.Column<string>(nullable: false),
                    Project_description = table.Column<string>(nullable: false),
                    Project_location = table.Column<string>(nullable: false),
                    Project_nature = table.Column<string>(nullable: false),
                    Project_startDate = table.Column<DateTime>(nullable: false),
                    Project_dueDate = table.Column<DateTime>(nullable: false),
                    Project_endDate = table.Column<DateTime>(nullable: false),
                    Project_budget = table.Column<double>(nullable: false),
                    Project_status = table.Column<string>(nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Project_Code);
                    table.ForeignKey(
                        name: "FK_Project_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assigned",
                columns: table => new
                {
                    AssignedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffID = table.Column<int>(nullable: false),
                    Project_Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigned", x => x.AssignedID);
                    table.ForeignKey(
                        name: "FK_Assigned_Project_Project_Code",
                        column: x => x.Project_Code,
                        principalTable: "Project",
                        principalColumn: "Project_Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assigned_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuppliedBy",
                columns: table => new
                {
                    SuppliedByID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierID = table.Column<int>(nullable: false),
                    Project_Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliedBy", x => x.SuppliedByID);
                    table.ForeignKey(
                        name: "FK_SuppliedBy_Project_Project_Code",
                        column: x => x.Project_Code,
                        principalTable: "Project",
                        principalColumn: "Project_Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuppliedBy_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assigned_Project_Code",
                table: "Assigned",
                column: "Project_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Assigned_StaffID",
                table: "Assigned",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientID",
                table: "Project",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliedBy_Project_Code",
                table: "SuppliedBy",
                column: "Project_Code");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliedBy_SupplierID",
                table: "SuppliedBy",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assigned");

            migrationBuilder.DropTable(
                name: "SuppliedBy");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
