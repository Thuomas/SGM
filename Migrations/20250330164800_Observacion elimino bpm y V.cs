using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGM.Migrations
{
    /// <inheritdoc />
    public partial class ObservacioneliminobpmyV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amp",
                table: "Observacion");

            migrationBuilder.DropColumn(
                name: "Bpm",
                table: "Observacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amp",
                table: "Observacion",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Bpm",
                table: "Observacion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
