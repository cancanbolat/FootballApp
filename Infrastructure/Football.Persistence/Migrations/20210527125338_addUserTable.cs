using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.Infrastructure.Persistence.Migrations
{
    public partial class addUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "UUID_GENERATE_V4()"),
                    first_name = table.Column<string>(type: "character varying", maxLength: 150, nullable: true),
                    last_name = table.Column<string>(type: "character varying", maxLength: 150, nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    email = table.Column<string>(type: "character varying", maxLength: 100, nullable: true),
                    username = table.Column<string>(type: "character varying", maxLength: 20, nullable: true),
                    password = table.Column<string>(type: "character varying", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "public");
        }
    }
}
