using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class CreateBreed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BreedId",
                table: "Animal",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_BreedId",
                table: "Animal",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Animal_BreedId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Animal");
        }
    }
}
