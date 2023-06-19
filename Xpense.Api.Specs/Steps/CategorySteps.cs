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
using Xpense.Data.Core.Database;
using Xpense.Data.Core.Entities;
using Xpense.Data.Core.Repository;

namespace Xpense.Api.Specs.Steps;

[Binding]
public sealed class CategorySteps
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private readonly ScenarioContext _scenarioContext;
    private HttpClient _httpClient;
    private HttpResponseMessage _response;
    private ExpenseCategoryAddModel _expenseCategoryAddModel;

    public CategorySteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
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
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5271/");
        
        var absUrl = new Uri(_httpClient.BaseAddress, url);
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(_expenseCategoryAddModel.Name), "Name");

        _response = await _httpClient.PostAsync(absUrl, formData);
        
        string responseBody = await _response.Content.ReadAsStringAsync();
        if (responseBody == "")
        {
            ExpenseCategory expenseCategory = JsonConvert.DeserializeObject<ExpenseCategory>(responseBody);
        }
    }

    [Then("the response status should be (.*)")]
    public void ThenTheResponseStatusShouldBe(HttpStatusCode expectedStatus)
    {
        _response.StatusCode.Should().Be(expectedStatus);
    }
}