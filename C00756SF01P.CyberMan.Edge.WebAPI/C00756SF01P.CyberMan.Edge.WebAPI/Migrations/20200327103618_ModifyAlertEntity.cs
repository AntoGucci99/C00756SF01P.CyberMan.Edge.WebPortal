using Microsoft.EntityFrameworkCore.Migrations;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Migrations
{
    public partial class ModifyAlertEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertMessage",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "TypeAllert",
                table: "Alerts");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Alerts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Alerts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Alerts");

            migrationBuilder.AddColumn<string>(
                name: "AlertMessage",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeAllert",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
