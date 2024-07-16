using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarriorsAndMagesRPG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identity key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterClass = table.Column<int>(type: "int", nullable: false, comment: "Character class enum"),
                    Health = table.Column<int>(type: "int", nullable: false, comment: "Character health"),
                    Strength = table.Column<int>(type: "int", nullable: false, comment: "Character strength"),
                    Agility = table.Column<int>(type: "int", nullable: false, comment: "Character agility"),
                    Intelligence = table.Column<int>(type: "int", nullable: false, comment: "Character intelligence"),
                    Damage = table.Column<int>(type: "int", nullable: false, comment: "Character damage"),
                    Range = table.Column<int>(type: "int", nullable: false, comment: "Character range"),
                    CharacterSymbol = table.Column<string>(type: "nvarchar(1)", nullable: false, comment: "Character symbol"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of character creation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
