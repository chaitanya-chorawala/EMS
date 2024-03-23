using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ems.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class displaynameinregistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APILogs",
                schema: "Logging");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Registration",
                newName: "DisplayName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Logging");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "Registration",
                newName: "MiddleName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Registration",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Registration",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "APILogs",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Exception = table.Column<string>(type: "text", nullable: true),
                    Host = table.Column<string>(type: "text", nullable: false),
                    Method = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    QueryString = table.Column<string>(type: "text", nullable: true),
                    RequestAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RequestBody = table.Column<string>(type: "text", nullable: true),
                    ResponseAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ResponseBody = table.Column<string>(type: "text", nullable: true),
                    StatusCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APILogs", x => x.Id);
                });
        }
    }
}
