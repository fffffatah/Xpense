using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xpense.Data.Core.Database;

namespace Xpense.Api.Specs.Infrastructure;

public class TestContext : IDisposable
{
    private readonly WebApplicationFactory<TestStartup> _factory;
    public XpenseDatabaseContext DbContext { get; set; }
    public HttpClient HttpClient { get; set; }
    
    public TestContext()
    {
        _factory = new WebApplicationFactory<TestStartup>();

        // Get an instance of the in-memory database context
        //DbContext = _factory.Services.GetRequiredService<XpenseDatabaseContext>();

        // Perform any additional setup, such as database seeding, if needed
        SeedTestData();

        // Create an HTTP client for making requests to the in-memory API
        HttpClient = _factory.CreateClient();
        HttpClient.BaseAddress = new Uri("http://localhost:5271/");
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
        _factory?.Dispose();
        HttpClient?.Dispose();
    }
}