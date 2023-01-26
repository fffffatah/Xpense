using Microsoft.Extensions.DependencyInjection;
using Xpense.Extension.Core.Database;

namespace Xpense.Extension.Core
{
    public static class CoreServiceExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection service)
        {
            service.AddDbContext<XpenseDatabaseContext>(options => options.Us)
        }
    }
}
