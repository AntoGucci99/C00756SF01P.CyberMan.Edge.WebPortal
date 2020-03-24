using Microsoft.EntityFrameworkCore.Migrations;

namespace C00756SF01P.CyberMan.Edge.WebAPI.Migrations
{
    public partial class ChangeColumNameStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("NameStatus", "Statuses", "StatusName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("StatusName", "Statuses", "NameStatus");
        }
    }
}
