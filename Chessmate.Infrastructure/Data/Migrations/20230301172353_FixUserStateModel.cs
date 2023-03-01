using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chessmate.Infrastructure.Data.Migrations
{
    public partial class FixUserStateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isOnline",
                table: "UserStates",
                newName: "IsOnline");

            migrationBuilder.RenameColumn(
                name: "isOccupied",
                table: "UserStates",
                newName: "IsOccupied");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOnline",
                table: "UserStates",
                newName: "isOnline");

            migrationBuilder.RenameColumn(
                name: "IsOccupied",
                table: "UserStates",
                newName: "isOccupied");
        }
    }
}
