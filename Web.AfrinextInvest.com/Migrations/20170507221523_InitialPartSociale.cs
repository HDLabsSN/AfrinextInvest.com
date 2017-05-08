using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.AfrinextInvest.com.Migrations
{
    public partial class InitialPartSociale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartSociale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ActiviteVerifiee = table.Column<bool>(nullable: false),
                    AgeActivite = table.Column<int>(nullable: false),
                    ChiffreAffaire = table.Column<decimal>(nullable: false),
                    DescriptionActivite = table.Column<string>(nullable: true),
                    NbPartsACeder = table.Column<int>(nullable: false),
                    NomActivite = table.Column<string>(nullable: true),
                    Pays = table.Column<string>(nullable: true),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    SecteurActivite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSociale", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartSociale");
        }
    }
}
