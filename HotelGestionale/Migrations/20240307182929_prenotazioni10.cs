using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelGestionale.Migrations
{
    /// <inheritdoc />
    public partial class prenotazioni10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Camere_IDCamera",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Clienti_IDCliente",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_TipoPensione_IDTipoPensione",
                table: "Prenotazioni");

            migrationBuilder.AlterColumn<int>(
                name: "IDTipoPensione",
                table: "Prenotazioni",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IDCliente",
                table: "Prenotazioni",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IDCamera",
                table: "Prenotazioni",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Camere_IDCamera",
                table: "Prenotazioni",
                column: "IDCamera",
                principalTable: "Camere",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Clienti_IDCliente",
                table: "Prenotazioni",
                column: "IDCliente",
                principalTable: "Clienti",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_TipoPensione_IDTipoPensione",
                table: "Prenotazioni",
                column: "IDTipoPensione",
                principalTable: "TipoPensione",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Camere_IDCamera",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Clienti_IDCliente",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_TipoPensione_IDTipoPensione",
                table: "Prenotazioni");

            migrationBuilder.AlterColumn<int>(
                name: "IDTipoPensione",
                table: "Prenotazioni",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IDCliente",
                table: "Prenotazioni",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IDCamera",
                table: "Prenotazioni",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Camere_IDCamera",
                table: "Prenotazioni",
                column: "IDCamera",
                principalTable: "Camere",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Clienti_IDCliente",
                table: "Prenotazioni",
                column: "IDCliente",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_TipoPensione_IDTipoPensione",
                table: "Prenotazioni",
                column: "IDTipoPensione",
                principalTable: "TipoPensione",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
