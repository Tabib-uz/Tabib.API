using Microsoft.EntityFrameworkCore;
using Tabib.Infrastructure.Persistence;

namespace Tabib.Api.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
#if DEBUG
        services.AddDbContext<TabibDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("TabibUzConnectionString")));
#else
        services.AddDbContext<TabibDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TabibUzConnectionString")));
#endif
        return services;
    }
}
