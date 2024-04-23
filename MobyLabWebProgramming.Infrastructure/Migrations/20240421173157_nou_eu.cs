using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class nou_eu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_Animal_Id",
                table: "AdoptionRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "BreedId",
                table: "Animal",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
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

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_AnimalId",
                table: "AdoptionRequests",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_Animal_AnimalId",
                table: "AdoptionRequests",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_Animal_AnimalId",
                table: "AdoptionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_AnimalId",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "AdoptionRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_Animal_Id",
                table: "AdoptionRequests",
                column: "Id",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
