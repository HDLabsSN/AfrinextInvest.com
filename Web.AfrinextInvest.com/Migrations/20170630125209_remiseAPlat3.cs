using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.AfrinextInvest.com.Migrations
{
    public partial class remiseAPlat3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "Projets",
                maxLength: 480,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projets",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 480);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resume",
                table: "Projets");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projets",
                maxLength: 480,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
