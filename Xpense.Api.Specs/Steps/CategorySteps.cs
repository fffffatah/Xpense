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
using Xpense.Extension.Core.Database;
using Xpense.Extension.Core.Entities;
using Xpense.Extension.Core.Repository;

namespace Xpense.Api.Specs.Steps;

[Binding]
public sealed class CategorySteps
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private HttpClient _httpClient;
    private HttpResponseMessage _response;
    private ExpenseCategoryAddModel _expenseCategoryAddModel;
    private readonly IRepository<ExpenseCategory> _repository;
    private readonly Hooks<ExpenseCategory> _hooks;

    public CategorySteps(ScenarioContext scenarioContext, IRepository<ExpenseCategory> repository)
    {
        _scenarioContext = scenarioContext;
        _repository = repository;
        _hooks = new Hooks<ExpenseCategory>(_repository);
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
        
            _hooks.TrackEntity(expenseCategory);
        }
    }

    [Then("the response status should be (.*)")]
    public void ThenTheResponseStatusShouldBe(HttpStatusCode expectedStatus)
    {
        _response.StatusCode.Should().Be(expectedStatus);
    }
}