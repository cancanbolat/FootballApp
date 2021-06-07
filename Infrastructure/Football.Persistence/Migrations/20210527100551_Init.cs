using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Football.Infrastructure.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "positions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_position_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", maxLength: 150, nullable: true),
                    logo = table.Column<string>(type: "character varying", maxLength: 150, nullable: true, defaultValue: "default_profile.png")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "UUID_GENERATE_V4()"),
                    first_name = table.Column<string>(type: "character varying", maxLength: 150, nullable: true),
                    last_name = table.Column<string>(type: "character varying", maxLength: 150, nullable: true),
                    photo = table.Column<string>(type: "character varying", maxLength: 250, nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_id", x => x.id);
                    table.ForeignKey(
                        name: "pk_player_positin_id",
                        column: x => x.PositionId,
                        principalSchema: "public",
                        principalTable: "positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "pk_player_team_id",
                        column: x => x.TeamId,
                        principalSchema: "public",
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_PositionId",
                schema: "public",
                table: "players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_players_TeamId",
                schema: "public",
                table: "players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players",
                schema: "public");

            migrationBuilder.DropTable(
                name: "positions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "teams",
                schema: "public");
        }
    }
}
