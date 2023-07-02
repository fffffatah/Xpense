using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xpense.Api.Specs.Endpoints;
using Xpense.Data.Core.Database;

namespace Xpense.Api.Specs.Infrastructure;

public class TestContext : IDisposable
{
    private readonly TestServer _testServer;
    //public XpenseDatabaseContext DbContext { get; set; }
    public HttpClient HttpClient { get; set; }
    
    public TestContext()
    {
        var builder = new WebHostBuilder()
            .UseStartup<TestStartup>()
            .UseEnvironment("Testing");

        _testServer = new TestServer(builder);
        // Get an instance of the in-memory database context
        //DbContext = _testServer.Services.GetRequiredService<XpenseDatabaseContext>();

        // Perform any additional setup, such as database seeding, if needed
        SeedTestData();

        // Create an HTTP client for making requests to the in-memory API
        HttpClient = _testServer.CreateClient();
        HttpClient.BaseAddress = new Uri(BaseUrl.BaseApiUrl);
    }
    
    private void SeedTestData()
    {
        // Code to seed test data in the in-memory database
        // DbContext.SomeEntities.Add(...);
        // DbContext.SaveChanges();
    }

    public void Dispose()
    {
        // Clean up resources after each test, if any
        _testServer?.Dispose();
        HttpClient?.Dispose();
    }
}