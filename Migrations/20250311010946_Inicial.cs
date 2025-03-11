using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jendri_Hidalgo_P2_AP1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "Encuesta",
                columns: table => new
                {
                    EncuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asignatura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuesta", x => x.EncuestaId);
                });

            migrationBuilder.CreateTable(
                name: "CiudadesDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiudadesDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CiudadesDetalle_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CiudadesDetalle_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "EncuestaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CiudadesDetalle_CiudadId",
                table: "CiudadesDetalle",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_CiudadesDetalle_EncuestaId",
                table: "CiudadesDetalle",
                column: "EncuestaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CiudadesDetalle");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Encuesta");
        }
    }
}
