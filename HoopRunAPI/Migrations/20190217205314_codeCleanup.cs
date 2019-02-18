using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoopRunAPI.Migrations
{
    public partial class codeCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "GymOwner",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "GymOwner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "GymOwner",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "GymOwner",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "GymOwner");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "GymOwner");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "GymOwner");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GymOwner");

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 40, nullable: false),
                    Lastname = table.Column<string>(maxLength: 40, nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(maxLength: 40, nullable: false),
                    addressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_addressId",
                table: "UserModel",
                column: "addressId");
        }
    }
}
