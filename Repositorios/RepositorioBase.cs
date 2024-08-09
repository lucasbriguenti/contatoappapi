using ContatoAppApi.Data;
using ContatoAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatoAppApi.Repositorios;

public class RepositorioBase<T>(AppDbContext context) : IRepositorioBase<T> where T : EntidadeBase
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly AppDbContext _context = context;

    public Task<T?> ObterPorId(int id)
    {
        return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<T[]> ObterTodos()
    {
        return _dbSet.ToArrayAsync();
    }

    public async Task<bool> Remover(int id)
    {
        var entidade = await ObterPorId(id);
        if (entidade is not null)
            _dbSet.Remove(entidade);
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task Salvar(T entidade)
    {
        await _dbSet.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public Task Commit()
    {
        return _context.SaveChangesAsync();
    }
}
