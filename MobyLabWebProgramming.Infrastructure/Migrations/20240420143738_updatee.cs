using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class updatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Shelters_ShelterId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ShelterId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "Animal");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Shelters_Id",
                table: "Animal",
                column: "Id",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Shelters_Id",
                table: "Animal");

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
                table: "Animal",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ShelterId",
                table: "Animal",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Shelters_ShelterId",
                table: "Animal",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
