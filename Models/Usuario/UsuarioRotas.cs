using ContatoAppApi.Data;
using ContatoAppApi.Models.Usuario.Dtos;
using ContatoAppApi.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ContatoAppApi.Models.Usuario;

public static class UsuarioRotas
{
    public static WebApplication AddUsuariosRotas(this WebApplication app)
    {
        var rotas = app.MapGroup("Usuarios").WithTags("Usuarios");

        rotas.MapGet("", (IRepositorioBase<Usuario> repositorio) =>
        {
            return repositorio.ObterTodos();
        });

        rotas.MapPost("", async (AdicionarUsuarioDto dto, IRepositorioBase<Usuario> repositorio) =>
        {
            if (dto is null) return Results.BadRequest();

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Sobrenome = dto.Sobrenome,
                Email = dto.Email,
                Senha = dto.Senha,
                ChaveAcesso = $"{dto.Nome}.{dto.Sobrenome}".ToLower()
            };

            await repositorio.Salvar(usuario);
            return Results.Created("", usuario);
        });

        return app;
    }
}
