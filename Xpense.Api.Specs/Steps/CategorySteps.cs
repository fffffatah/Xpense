using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FluentAssertions;
using Xpense.Api.Models;

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
    }

    [Then("the response status should be (.*)")]
    public void ThenTheResponseStatusShouldBe(HttpStatusCode expectedStatus)
    {
        _response.StatusCode.Should().Be(expectedStatus);
    }
}