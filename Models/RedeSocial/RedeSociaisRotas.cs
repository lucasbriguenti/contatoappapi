using ContatoAppApi.Data;
using ContatoAppApi.Models.RedeSocial.Dtos;
using ContatoAppApi.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ContatoAppApi.Models.RedeSocial;

public static class RedeSociaisRotas
{
    public static WebApplication AddRedesSociaisRotas(this WebApplication app)
    {
        var rotas = app.MapGroup("RedesSociais")
            .WithTags("RedesSociais");
        rotas.MapPost("", async (AdicionarRedeSocialDto dto, IRepositorioBase<RedeSocial> repositorio) =>
        {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                return Results.BadRequest("Nome deve ser informado");
            }

            var redeSocial = new RedeSocial
            {
                Nome = dto.Nome,
                UrlBase = dto.UrlBase
            };
            await repositorio.Salvar(redeSocial);
            return Results.Created("{id}", redeSocial);
        });

        rotas.MapGet("{id}", async (int id, IRepositorioBase<RedeSocial> repositorio) =>
        {
            var resultado = await repositorio.ObterPorId(id);
            return resultado is null
            ? Results.NotFound()
            : Results.Ok(resultado);
        });

        rotas.MapGet("", (AppDbContext context) =>
        {
            return context.RedeSociais.ToListAsync();
        });

        rotas.MapDelete("{id}", async (int id, IRepositorioBase<RedeSocial> repositorio) =>
        {
            var removeu = await repositorio.Remover(id);
            return removeu ? Results.Ok() : Results.NotFound();
        });

        rotas.MapPut("{id}", async (int id, AdicionarRedeSocialDto dto, IRepositorioBase<RedeSocial> repositorio) =>
        {
            var redeSocial = await repositorio.ObterPorId(id);
            if (redeSocial is null)
                return Results.NotFound();

            redeSocial.Nome = dto.Nome;
            redeSocial.UrlBase = dto.UrlBase;
            await repositorio.Commit();
            return Results.Ok(redeSocial);
        });

        return app;
    }
}
