using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowAuth.Migrations
{
    public partial class LogsTaskID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Task_DescriptionID",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "TaskDescriptionID",
                table: "Log",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TaskDescriptionID",
                table: "Log",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Task_DescriptionID",
                table: "Log",
                nullable: false,
                defaultValue: 0);
        }
    }
}
