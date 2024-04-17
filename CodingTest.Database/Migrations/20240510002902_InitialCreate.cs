using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingTest.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LegalName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    TradingName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    ABN = table.Column<string>(type: "TEXT", unicode: false, maxLength: 10, nullable: true),
                    ACN = table.Column<string>(type: "TEXT", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claimant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "TEXT", unicode: false, maxLength: 10, nullable: true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClaimantId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claimant_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    GivenName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FamilyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "TEXT", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyContactId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContact_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claimant_CompanyId",
                table: "Claimant",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContact_CompanyId",
                table: "CompanyContact",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claimant");

            migrationBuilder.DropTable(
                name: "CompanyContact");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
