using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MyCWebApp.Tests;

public class ProgramTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetRootEndpoint_ReturnsHelloWorld()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("Hello World!", content);
    }

    [Fact]
    public async Task GetRootEndpoint_Returns200Ok()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}
    