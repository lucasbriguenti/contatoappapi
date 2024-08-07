using ContatoAppApi.Data;
using ContatoAppApi.Models.RedeSocial.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ContatoAppApi.Models.RedeSocial;

public static class RedeSociaisRotas
{
    public static WebApplication AddRedesSociaisRotas(this WebApplication app)
    {
        var rotas = app.MapGroup("RedesSociais")
            .WithTags("RedesSociais");
        rotas.MapPost("", async (AdicionarRedeSocialDto dto, AppDbContext context) =>
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
            await context.RedeSociais.AddAsync(redeSocial);
            await context.SaveChangesAsync();
            return Results.Created("{id}", redeSocial);
        });

        rotas.MapGet("{id}", async (int id, AppDbContext context) =>
        {
            var resultado = await context.RedeSociais.FirstOrDefaultAsync(x => x.Id == id);
            return resultado is null
            ? Results.NotFound()
            : Results.Ok(resultado);
        });

        rotas.MapGet("", (AppDbContext context) =>
        {
            return context.RedeSociais.ToListAsync();
        });

        rotas.MapDelete("{id}", async (int id, AppDbContext context) =>
        {
            var redeSocial = await context.RedeSociais.FirstOrDefaultAsync(x => x.Id == id);
            if (redeSocial is null)
                return Results.NotFound();

            context.RedeSociais.Remove(redeSocial);
            await context.SaveChangesAsync();
            return Results.Ok();
        });

        rotas.MapPut("{id}", async (int id, AdicionarRedeSocialDto dto, AppDbContext context) =>
        {
            var redeSocial = await context.RedeSociais.FirstOrDefaultAsync(x => x.Id == id);
            if (redeSocial is null)
                return Results.NotFound();

            redeSocial.Nome = dto.Nome;
            redeSocial.UrlBase = dto.UrlBase;
            await context.SaveChangesAsync();
            return Results.Ok(redeSocial);
        });

        return app;
    }
}
