using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class updateee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_Animal_AnimalId",
                table: "AdoptionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_User_UserId",
                table: "AdoptionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_BreedId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_AnimalId",
                table: "AdoptionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_UserId",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AdoptionRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_Animal_Id",
                table: "AdoptionRequests",
                column: "Id",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_User_Id",
                table: "AdoptionRequests",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Breeds_Id",
                table: "Animal",
                column: "Id",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_Animal_Id",
                table: "AdoptionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_User_Id",
                table: "AdoptionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Breeds_Id",
                table: "Animal");

            migrationBuilder.AddColumn<Guid>(
                name: "BreedId",
                table: "Animal",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalId",
                table: "AdoptionRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AdoptionRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Animal_BreedId",
                table: "Animal",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_AnimalId",
                table: "AdoptionRequests",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_UserId",
                table: "AdoptionRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_Animal_AnimalId",
                table: "AdoptionRequests",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_User_UserId",
                table: "AdoptionRequests",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
