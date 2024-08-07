using System;
using ContatoAppApi.Data;

namespace ContatoAppApi.Utils;

public static class ServicesConfig
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
    }
}
