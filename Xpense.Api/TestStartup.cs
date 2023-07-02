using Microsoft.EntityFrameworkCore;
using Xpense.Data.Core.Database;
using Xpense.Data.Core.Repository;
using Xpense.Data.Core.Services;

namespace Xpense.Api;

public class TestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Configure services for the test environment
        services.AddDbContext<XpenseDatabaseContext>(options =>
        {
            options.UseInMemoryDatabase("Xpense");
        });

        services.AddControllers();
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
    }
        
    public void Configure(IApplicationBuilder app)
    {
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}