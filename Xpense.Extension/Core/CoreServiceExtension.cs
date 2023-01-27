using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using Xpense.Extension.Core.Database;
using Xpense.Extension.Core.Repository;
using Xpense.Extension.Core.Services;

namespace Xpense.Extension.Core
{
    public static class CoreServiceExtension
    {
        /// <summary>
        /// Add Core Services through Dependency Injection (Database Configuration and Repository)
        /// </summary>
        /// <param name="connectionString">SQL Server Conncetion String</param>
        /// <returns>Service</returns>
        public static IServiceCollection AddCoreServices(this IServiceCollection service, string connectionString)
        {
            /* Sql Server Configuration and Validation */
            service.Configure<SqlServerConfiguration>(x =>
            {
                x.ConnectionString = connectionString;
            });

            service.AddSingleton<IValidateOptions<SqlServerConfiguration>, SqlServerConfigurationValidation>();
            var sqlServerConfigurationInjection = service.BuildServiceProvider().GetRequiredService<IOptions<SqlServerConfiguration>>().Value;
            service.AddSingleton<ISqlServerConfiguration>(sqlServerConfigurationInjection);

            var serviceProvider = service.BuildServiceProvider();
            var sqlServerConfiguration = serviceProvider.GetRequiredService<ISqlServerConfiguration>();

            /* Dependency Injection */
            service.AddDbContext<XpenseDatabaseContext>(options => options.UseSqlServer(
                sqlServerConfiguration.ConnectionString, x => x.MigrationsAssembly(Assembly.GetEntryAssembly().GetName().Name)));

            var databaseContext = service.BuildServiceProvider().GetRequiredService<XpenseDatabaseContext>();
            databaseContext.Database.EnsureCreated();
            databaseContext.Database.Migrate();

            service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IExpenseService, ExpenseService>();
            service.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();

            return service;
        }
    }
}
