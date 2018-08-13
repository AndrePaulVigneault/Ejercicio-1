using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ejercicio_1EntityFramework.Migrations
{
    public partial class eso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Personas_PersonaCedula",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_PersonaCedula",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "PersonaCedula",
                table: "Mascotas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonaCedula",
                table: "Mascotas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_PersonaCedula",
                table: "Mascotas",
                column: "PersonaCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Personas_PersonaCedula",
                table: "Mascotas",
                column: "PersonaCedula",
                principalTable: "Personas",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
