using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContatoAppApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadaChaveAcesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChaveAcesso",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveAcesso",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Usuarios");
        }
    }
}
