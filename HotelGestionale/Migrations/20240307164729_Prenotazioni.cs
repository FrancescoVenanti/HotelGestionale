using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelGestionale.Migrations
{
    /// <inheritdoc />
    public partial class Prenotazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInizioSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFineSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acconto = table.Column<double>(type: "float", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDCamera = table.Column<int>(type: "int", nullable: false),
                    IDPensione = table.Column<int>(type: "int", nullable: false),
                    tipoPensioneID = table.Column<int>(type: "int", nullable: false),
                    IDTipoPensione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Camere_IDCamera",
                        column: x => x.IDCamera,
                        principalTable: "Camere",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Clienti_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_TipoPensione_tipoPensioneID",
                        column: x => x.tipoPensioneID,
                        principalTable: "TipoPensione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IDCamera",
                table: "Prenotazioni",
                column: "IDCamera");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IDCliente",
                table: "Prenotazioni",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_tipoPensioneID",
                table: "Prenotazioni",
                column: "tipoPensioneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazioni");
        }
    }
}
