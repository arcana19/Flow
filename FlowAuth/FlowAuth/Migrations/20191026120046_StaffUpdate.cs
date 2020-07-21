using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class StaffUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phases_PhaseNames_PhaseNameID",
                table: "Phases");

            migrationBuilder.DropForeignKey(
                name: "FK_Phases_Project_Project_Code",
                table: "Phases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phases",
                table: "Phases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhaseNames",
                table: "PhaseNames");

            migrationBuilder.RenameTable(
                name: "Phases",
                newName: "Phase");

            migrationBuilder.RenameTable(
                name: "PhaseNames",
                newName: "PhaseName");

            migrationBuilder.RenameIndex(
                name: "IX_Phases_Project_Code",
                table: "Phase",
                newName: "IX_Phase_Project_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Phases_PhaseNameID",
                table: "Phase",
                newName: "IX_Phase_PhaseNameID");

            migrationBuilder.AlterColumn<long>(
                name: "Staff_passport",
                table: "Staff",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Staff_incomeTax",
                table: "Staff",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Staff_idNum",
                table: "Staff",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<double>(
                name: "Staff_leaveDays",
                table: "Staff",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Staff_rate",
                table: "Staff",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phase",
                table: "Phase",
                column: "PhaseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhaseName",
                table: "PhaseName",
                column: "PhaseNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phase_PhaseName_PhaseNameID",
                table: "Phase",
                column: "PhaseNameID",
                principalTable: "PhaseName",
                principalColumn: "PhaseNameID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phase_Project_Project_Code",
                table: "Phase",
                column: "Project_Code",
                principalTable: "Project",
                principalColumn: "Project_Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phase_PhaseName_PhaseNameID",
                table: "Phase");

            migrationBuilder.DropForeignKey(
                name: "FK_Phase_Project_Project_Code",
                table: "Phase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhaseName",
                table: "PhaseName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phase",
                table: "Phase");

            migrationBuilder.DropColumn(
                name: "Staff_leaveDays",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Staff_rate",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "PhaseName",
                newName: "PhaseNames");

            migrationBuilder.RenameTable(
                name: "Phase",
                newName: "Phases");

            migrationBuilder.RenameIndex(
                name: "IX_Phase_Project_Code",
                table: "Phases",
                newName: "IX_Phases_Project_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Phase_PhaseNameID",
                table: "Phases",
                newName: "IX_Phases_PhaseNameID");

            migrationBuilder.AlterColumn<long>(
                name: "Staff_passport",
                table: "Staff",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Staff_incomeTax",
                table: "Staff",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Staff_idNum",
                table: "Staff",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhaseNames",
                table: "PhaseNames",
                column: "PhaseNameID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phases",
                table: "Phases",
                column: "PhaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phases_PhaseNames_PhaseNameID",
                table: "Phases",
                column: "PhaseNameID",
                principalTable: "PhaseNames",
                principalColumn: "PhaseNameID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phases_Project_Project_Code",
                table: "Phases",
                column: "Project_Code",
                principalTable: "Project",
                principalColumn: "Project_Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
