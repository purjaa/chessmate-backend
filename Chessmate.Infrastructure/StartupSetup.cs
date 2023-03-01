using Chessmate.Infrastructure.Data;
using Chessmate.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chessmate.Infrastructure;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(connectionString)); // will be created in web project root

        services.AddDbContext<UserStateContext>(options =>
            options.UseSqlServer(connectionString)); // will be created in web project root
    }
}
