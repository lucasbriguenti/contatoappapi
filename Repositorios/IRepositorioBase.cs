using ContatoAppApi.Models;

namespace ContatoAppApi.Repositorios;

public interface IRepositorioBase<T> where T : EntidadeBase
{
    Task<T[]> ObterTodos();
    Task<T?> ObterPorId(int id);
    Task Salvar(T entidade);
    Task<bool> Remover(int id);
    Task Commit();
}
