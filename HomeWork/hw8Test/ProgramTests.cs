using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace hw8.Tests
{
	public class HostBuilder : WebApplicationFactory<Startup>
	{
		protected override IHostBuilder CreateHostBuilder()
			=> Host
				.CreateDefaultBuilder()
				.ConfigureWebHostDefaults(a => a
					.UseStartup<Startup>()
					.UseTestServer());
	}
	
	public class ProgramTests : IClassFixture<HostBuilder>
	{
		private readonly HttpClient client;
		public ProgramTests(HostBuilder fixture)
		{
			client = fixture.CreateClient();
		}
		
		[Theory]
		[InlineData("2", "Add", "4", "6")]
		[InlineData("10", "Subtract", "4", "6")]
		[InlineData("3", "Multiply", "5", "15")]
		[InlineData("10", "Divide", "5", "2")]
		[InlineData("2.3", "Add", "3.1", "5.4")]
		[InlineData("2.5", "Multiply", "0", "0")]
		[InlineData("1.5", "Divide", "1.5", "1")]
		public async Task Main_CorrectExpression_ReturnCorrectResult(string v1,
			string operation,
			string v2,
			string expected)
		{
			await DoTest(v1, operation, v2, expected);
		}

		[Theory]
		[InlineData("x", "Add", "4", "4")]
		[InlineData("p", "Subtract", "4", "-4")]
		[InlineData("dream", "Multiply", "team", "0")]
		public async Task Main_InvalidExpression_ReturnMessageError(string v1,
			string operation,
			string v2,
			string expected)
		{
			await DoTest(v1, operation, v2, expected);
		}
		
		[Theory]
		[InlineData("10", "Divide", "0", "0")]
		[InlineData("2.4", "Divide", "0", "0")]
		public async Task Main_DivideZero_ReturnMessageError(string v1,
			string operation,
			string v2,
			string expected)
		{
			await DoTest(v1, operation, v2, expected);
		}

		private async Task DoTest(string v1, string operation, string v2, string expected)
		{
			var response =
				await client.GetAsync($"https://localhost:5001/Calculator/{operation}?val1={v1}&val2={v2}");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, result);
		}
	}
}