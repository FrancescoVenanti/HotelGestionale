using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelGestionale.Migrations
{
    /// <inheritdoc />
    public partial class servizi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataServizio",
                table: "Servizi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataServizio",
                table: "Servizi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
