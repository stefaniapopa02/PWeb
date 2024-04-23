using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class adddProfilesuidatmeeeguk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_User_Id",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Shelter_Breed",
                columns: table => new
                {
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: false),
                    BreedId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter_Breed", x => new { x.ShelterId, x.BreedId });
                    table.ForeignKey(
                        name: "FK_Shelter_Breed_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shelter_Breed_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_Breed_BreedId",
                table: "Shelter_Breed",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_User_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_User_UserId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Shelter_Breed");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_User_Id",
                table: "Profiles",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
