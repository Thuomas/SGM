using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGM.Migrations
{
    /// <inheritdoc />
    public partial class InsumoCriticoSimplificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "InsumoCritico");

            migrationBuilder.RenameColumn(
                name: "Lote",
                table: "InsumoCritico",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "InsumoCritico",
                newName: "Lote");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "InsumoCritico",
                type: "TEXT",
                nullable: true);
        }
    }
}
