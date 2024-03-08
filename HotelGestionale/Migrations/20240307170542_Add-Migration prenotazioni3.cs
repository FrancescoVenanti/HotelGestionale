using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelGestionale.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationprenotazioni3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_TipoPensione_tipoPensioneID",
                table: "Prenotazioni");

            migrationBuilder.DropIndex(
                name: "IX_Prenotazioni_tipoPensioneID",
                table: "Prenotazioni");

            migrationBuilder.DropColumn(
                name: "tipoPensioneID",
                table: "Prenotazioni");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IDTipoPensione",
                table: "Prenotazioni",
                column: "IDTipoPensione");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_TipoPensione_IDTipoPensione",
                table: "Prenotazioni",
                column: "IDTipoPensione",
                principalTable: "TipoPensione",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_TipoPensione_IDTipoPensione",
                table: "Prenotazioni");

            migrationBuilder.DropIndex(
                name: "IX_Prenotazioni_IDTipoPensione",
                table: "Prenotazioni");

            migrationBuilder.AddColumn<int>(
                name: "tipoPensioneID",
                table: "Prenotazioni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_tipoPensioneID",
                table: "Prenotazioni",
                column: "tipoPensioneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_TipoPensione_tipoPensioneID",
                table: "Prenotazioni",
                column: "tipoPensioneID",
                principalTable: "TipoPensione",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
