using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ejercicio_1EntityFramework.Migrations
{
    public partial class aas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Cedula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstadoAdopcion = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    PersonaCedula = table.Column<int>(nullable: true),
                    Raza = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Personas_PersonaCedula",
                        column: x => x.PersonaCedula,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persona_Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MascotaId = table.Column<int>(nullable: true),
                    PersonaCedula = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Mascotas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Mascotas_Personas_PersonaCedula",
                        column: x => x.PersonaCedula,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_PersonaCedula",
                table: "Mascotas",
                column: "PersonaCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Mascotas_MascotaId",
                table: "Persona_Mascotas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Mascotas_PersonaCedula",
                table: "Persona_Mascotas",
                column: "PersonaCedula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona_Mascotas");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
