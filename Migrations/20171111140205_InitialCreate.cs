using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace convertizzle.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    ApiKey = table.Column<string>(type: "text", nullable: true),
                    Credits = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Conversions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountEmail = table.Column<string>(type: "text", nullable: true),
                    ConversionDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ConversionEnded = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ConversionStarted = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ConvertedContentSize = table.Column<double>(type: "float8", nullable: false),
                    ExceptionDetails = table.Column<string>(type: "text", nullable: true),
                    Filename = table.Column<string>(type: "text", nullable: true),
                    OriginalContentSize = table.Column<double>(type: "float8", nullable: false),
                    Succeeded = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversions_Accounts_AccountEmail",
                        column: x => x.AccountEmail,
                        principalTable: "Accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_AccountEmail",
                table: "Conversions",
                column: "AccountEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversions");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
