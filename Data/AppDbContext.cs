using ContatoAppApi.Models.RedeSocial;
using ContatoAppApi.Models.Usuario;
using ContatoAppApi.Models.UsuarioRedeSocial;
using Microsoft.EntityFrameworkCore;

namespace ContatoAppApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<RedeSocial> RedeSociais { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioRedeSocial> UsuarioRedeSociais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ContatoAppDB.db");
    }
}
