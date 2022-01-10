using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using hw13;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{
    public class JsonCalculatorTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public JsonCalculatorTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Theory]
        [InlineData("2 + 3", 5)]
        [InlineData("2 - 3", -1)]
        [InlineData("2 * 3", 6)]
        [InlineData("2 / 3", 0.6666666666667)]
        [InlineData("(1 + 2) * 3", 9)]
        [InlineData("1 + (2 - 8)", -5)]
        [InlineData("(2+3) / 12 * 7 + 8 * 9", 74.9166666667)]
        public async Task Test1(string expr, double expected)
        {
            // Arrange
            var url = $"/Calculator/JsonCached?request={UrlEncoder.Create().Encode(expr)}";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var strResult = await response.Content.ReadAsStringAsync();
            var result = double.Parse(strResult, NumberStyles.Any, CultureInfo.InvariantCulture);
            Assert.Equal(expected, result, 5);
        }

        [Fact]
        public async Task TestAsync()
        {
            // Arrange
            const string expr = "1 + 2";
            const int count = 10;
            var timeLimitMs = 1000 * 3;
            var url = $"/Calculator/JsonCached?request={UrlEncoder.Create().Encode(expr)}";
            var client = _factory.CreateClient();

            // Act
            var sw = new Stopwatch();
            sw.Start();
            
            var requests = Enumerable.Range(0, count)
                .Select(x => client.GetAsync(url));
            var responses = await Task.WhenAll(requests);
            sw.Stop();

            // Assert
            foreach (var response in responses) 
                response.EnsureSuccessStatusCode();
            Assert.InRange(sw.ElapsedMilliseconds, 0, timeLimitMs);
        }
    }
}