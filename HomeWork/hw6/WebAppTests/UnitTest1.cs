using System.Net;
using System.Threading.Tasks;
using WebApp;
using Xunit;

namespace WebAppTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestIndex_Page_ReturnNotFound()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("13", CalculatorOperations.Addition, "21", "Result = 34")]
        [InlineData("9", CalculatorOperations.Subtract, "5", "Result = 4")]
        [InlineData("10", CalculatorOperations.Multiply, "2", "Result = 20")]
        [InlineData("10", CalculatorOperations.Divide, "5", "Result = 2")]
        public async Task TestResult_Process_Endpoint(string n1, string operation, string n2, string result)
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync($"/process?num1={n1}&num2={n2}&operation={operation}");
            var contentResult = response.Content.ReadAsStringAsync().Result;
            Assert.Equal(contentResult, result);
        }
    }
}