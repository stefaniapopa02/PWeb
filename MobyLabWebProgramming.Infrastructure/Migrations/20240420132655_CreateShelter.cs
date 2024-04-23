using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class CreateShelter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
                table: "Animal",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Shelters_ShelterId",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "Shelters");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ShelterId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "Animal");
        }
    }
}
