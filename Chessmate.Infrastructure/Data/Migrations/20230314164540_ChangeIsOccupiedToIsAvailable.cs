using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chessmate.Infrastructure.Data.Migrations
{
    public partial class ChangeIsOccupiedToIsAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOccupied",
                table: "UserStates",
                newName: "IsAvailable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "UserStates",
                newName: "IsOccupied");
        }
    }
}
