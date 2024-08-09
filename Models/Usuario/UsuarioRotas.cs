using ContatoAppApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ContatoAppApi.Models.Usuario;

public static class UsuarioRotas
{
    public static WebApplication AddUsuariosRotas(this WebApplication app)
    {
        var rotas = app.MapGroup("Usuarios").WithTags("Usuarios");

        rotas.MapGet("", (AppDbContext context) =>
        {
            return context.Usuarios.ToListAsync();
        });

        return app;
    }
}
