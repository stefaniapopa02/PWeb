using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class updateConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Breeds_Id",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Shelters_Id",
                table: "Animal");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_BreedId",
                table: "Animal",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ShelterId",
                table: "Animal",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Shelters_ShelterId",
                table: "Animal",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Shelters_ShelterId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_BreedId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ShelterId",
                table: "Animal");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Breeds_Id",
                table: "Animal",
                column: "Id",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Shelters_Id",
                table: "Animal",
                column: "Id",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
