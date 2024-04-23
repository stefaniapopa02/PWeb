using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class CreateAdoptionHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdoptionHistory",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdoptionStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdoptionEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionHistory", x => new { x.UserId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_AdoptionHistory_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdoptionHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionHistory_AnimalId",
                table: "AdoptionHistory",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionHistory");
        }
    }
}
