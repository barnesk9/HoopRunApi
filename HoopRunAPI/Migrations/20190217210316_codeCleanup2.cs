using Microsoft.EntityFrameworkCore.Migrations;

namespace HoopRunAPI.Migrations
{
    public partial class codeCleanup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerRun_Run_RunId",
                table: "PlayerRun");

            migrationBuilder.DropIndex(
                name: "IX_PlayerRun_RunId",
                table: "PlayerRun");

            migrationBuilder.AddColumn<int>(
                name: "RunId",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_RunId",
                table: "Player",
                column: "RunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Run_RunId",
                table: "Player",
                column: "RunId",
                principalTable: "Run",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Run_RunId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_RunId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "RunId",
                table: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRun_RunId",
                table: "PlayerRun",
                column: "RunId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerRun_Run_RunId",
                table: "PlayerRun",
                column: "RunId",
                principalTable: "Run",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
