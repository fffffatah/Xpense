using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using Xpense.Api.Models;
using Xpense.Api.Specs.Hooks;
using Xpense.Api.Specs.Infrastructure;
using Xpense.Data.Core.Database;
using Xpense.Data.Core.Entities;
using Xpense.Data.Core.Repository;

namespace Xpense.Api.Specs.Steps;

[Binding]
public sealed class CategorySteps
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private readonly TestContext _testContext;
    private readonly ScenarioContext _scenarioContext;
    private HttpResponseMessage _response;
    private ExpenseCategoryAddModel _expenseCategoryAddModel;

    public CategorySteps(ScenarioContext scenarioContext, TestContext testContext)
    {
        _scenarioContext = scenarioContext;
        _testContext = testContext;
    }

    [Given("an expense category request with name \"(.*)\"")]
    public void GivenAnExpenseCategoryRequestWithName(string categoryName)
    {
        _expenseCategoryAddModel = new ExpenseCategoryAddModel
        {
            Name = categoryName
        };
    }

    [When("I send a POST request to \"(.*)\"")]
    public async Task WhenISendAPostRequestToUrl(string url)
    {
        // _httpClient = new HttpClient();
        // _httpClient.BaseAddress = new Uri("http://localhost:5271/");
        
        var absUrl = new Uri(_testContext.HttpClient.BaseAddress, url);
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(_expenseCategoryAddModel.Name), "Name");

        _response = await _testContext.HttpClient.PostAsync(absUrl, formData);
        Console.WriteLine(_response.Content);
    }

    [Then("the response status should be (.*)")]
    public void ThenTheResponseStatusShouldBe(HttpStatusCode expectedStatus)
    {
        _response.StatusCode.Should().Be(expectedStatus);
    }

    [Given(@"I have following expense categories")]
    public void GivenIHaveFollowingExpenseCategories(Table table)
    {
        ScenarioContext.StepIsPending();
    }
}