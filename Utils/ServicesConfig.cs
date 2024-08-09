using ContatoAppApi.Data;
using ContatoAppApi.Repositorios;

namespace ContatoAppApi.Utils;

public static class ServicesConfig
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
    }
}
