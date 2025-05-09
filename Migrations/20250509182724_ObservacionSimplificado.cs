using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGM.Migrations
{
    /// <inheritdoc />
    public partial class ObservacionSimplificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirmwareVersion",
                table: "Observacion");

            migrationBuilder.DropColumn(
                name: "Grabador",
                table: "Observacion");

            migrationBuilder.DropColumn(
                name: "NumSerieGrabador",
                table: "Observacion");

            migrationBuilder.DropColumn(
                name: "NumSerieSimulador",
                table: "Observacion");

            migrationBuilder.DropColumn(
                name: "Simulador",
                table: "Observacion");

            migrationBuilder.RenameColumn(
                name: "SoftAnalisis",
                table: "Observacion",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Observacion",
                newName: "SoftAnalisis");

            migrationBuilder.AddColumn<string>(
                name: "FirmwareVersion",
                table: "Observacion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grabador",
                table: "Observacion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumSerieGrabador",
                table: "Observacion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumSerieSimulador",
                table: "Observacion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Simulador",
                table: "Observacion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
