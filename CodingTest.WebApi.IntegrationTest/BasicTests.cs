using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using CodingTest.Domain;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CodingTest.WebApi.IntegrationTest;
public class BasicTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BasicTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    ///  Do not change test
    [Fact]
    public async Task GetCompanies()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/company?page=2&pagesize=10");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode); // Status Code 200-299

        var companies = await response.Content.ReadFromJsonAsync<Company[]>();
        Assert.NotNull(companies);
        Assert.NotEmpty(companies);
        // TODO: Should pass on real implementation
        Assert.Equal(10, companies.Length);
        Assert.Equal(11, companies[0].Id);
    }

    ///  Do not change test
    [Theory]
    [InlineData("/Company/1")]
    public async Task GetCompany(string data)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(data);

        // Assert
        // Will fail as it is not yet implemented.
        Assert.Equal(HttpStatusCode.OK, response.StatusCode); // Status Code 200-299

        var company = await response.Content.ReadFromJsonAsync<Company>();
        Assert.NotNull(company);
        Assert.Equal(1, company.Id);
    }

}