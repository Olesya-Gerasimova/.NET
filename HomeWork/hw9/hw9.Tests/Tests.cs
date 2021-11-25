using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace hw9.Tests
{
    public class BasicTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("2 + 2 * 6 / 3 - 10", "-4")]
        [InlineData("(2+4) / 12 * 7 + 8 * 9", "75.5")]
        [InlineData("2 + -2", "0")]
        [InlineData("5", "5")]
        [InlineData("-5", "-5")]
        [InlineData("100 - 92.5 + 1.5", "9")]
        public async Task PositiveTests(string expression, string expectedResult)
        {
            // Arrange
            var client = _factory.CreateClient();
            var expressionEncoded = HttpUtility.UrlEncode(expression);
            var url = $"Calculator?expression={expressionEncoded}";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("2 +", "Not enough arguments")]
        [InlineData("1++", "Not enough arguments")]
        [InlineData("(1 + 2", "Mismatched parenthesis")]
        [InlineData(")2(", "Mismatched parenthesis")]
        [InlineData("(1 + 2))", "Mismatched parenthesis")]
        [InlineData("2 ^ 2", "Wrong rpn")]
        public async Task NegativeTests(string expression, string expectedResult)
        {
            // Arrange
            var client = _factory.CreateClient();
            var expressionEncoded = HttpUtility.UrlEncode(expression);
            var url = $"Calculator?expression={expressionEncoded}";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedResult, result);
        }
    }
}