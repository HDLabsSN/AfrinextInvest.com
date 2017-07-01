using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.AfrinextInvest.com.Migrations
{
    public partial class remiseAPlat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "BudgetRequis",
                table: "Projets",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BudgetRequis",
                table: "Projets",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
