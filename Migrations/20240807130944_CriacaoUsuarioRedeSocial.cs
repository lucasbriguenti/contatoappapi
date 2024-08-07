using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContatoAppApi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoUsuarioRedeSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioRedeSociais",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    RedeSociailId = table.Column<int>(type: "INTEGER", nullable: false),
                    RedeSocialId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId1 = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRedeSociais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRedeSociais_RedeSociais_RedeSocialId",
                        column: x => x.RedeSocialId,
                        principalTable: "RedeSociais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRedeSociais_Usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRedeSociais_RedeSocialId",
                table: "UsuarioRedeSociais",
                column: "RedeSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRedeSociais_UsuarioId1",
                table: "UsuarioRedeSociais",
                column: "UsuarioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRedeSociais");
        }
    }
}
