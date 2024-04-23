using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class addProfileupdatmeeeguk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_User_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_User_Id",
                table: "Profiles",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_User_Id",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_User_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
