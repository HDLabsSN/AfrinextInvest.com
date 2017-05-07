using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.AfrinextInvest.com.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BudgetRequis = table.Column<decimal>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Pays = table.Column<string>(nullable: true),
                    SecteurActivite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projets");
        }
    }
}
