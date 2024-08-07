using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContatoAppApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoUsuarioRedeSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRedeSociais_Usuarios_UsuarioId1",
                table: "UsuarioRedeSociais");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioRedeSociais_UsuarioId1",
                table: "UsuarioRedeSociais");

            migrationBuilder.DropColumn(
                name: "RedeSociailId",
                table: "UsuarioRedeSociais");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "UsuarioRedeSociais");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRedeSociais_UsuarioId",
                table: "UsuarioRedeSociais",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRedeSociais_Usuarios_UsuarioId",
                table: "UsuarioRedeSociais",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRedeSociais_Usuarios_UsuarioId",
                table: "UsuarioRedeSociais");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioRedeSociais_UsuarioId",
                table: "UsuarioRedeSociais");

            migrationBuilder.AddColumn<int>(
                name: "RedeSociailId",
                table: "UsuarioRedeSociais",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId1",
                table: "UsuarioRedeSociais",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRedeSociais_UsuarioId1",
                table: "UsuarioRedeSociais",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRedeSociais_Usuarios_UsuarioId1",
                table: "UsuarioRedeSociais",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
