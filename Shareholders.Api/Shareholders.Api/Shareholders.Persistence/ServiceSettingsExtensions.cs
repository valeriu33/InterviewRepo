using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shareholders.Application;

namespace Shareholders.Persistence
{
    public static class ServiceSettingsExtensions {
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<IShareholdersContext, ShareholdersContext>(options => options
                    .UseSqlServer(connectionString, x => x.MigrationsAssembly("Shareholders.Persistence"))
                );
        }

    }
}