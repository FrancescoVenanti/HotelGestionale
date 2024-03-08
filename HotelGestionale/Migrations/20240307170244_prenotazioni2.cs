using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelGestionale.Migrations
{
    /// <inheritdoc />
    public partial class prenotazioni2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDPensione",
                table: "Prenotazioni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDPensione",
                table: "Prenotazioni",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
