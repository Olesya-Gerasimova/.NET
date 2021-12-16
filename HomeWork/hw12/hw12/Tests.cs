using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using hw6;
using hw8;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace hw12
{
    public class HostBuilderFSharp : WebApplicationFactory<App.Startup>
    {
        protected override IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a =>
                    a.UseStartup<App.Startup>()
                        .UseTestServer());
    }

    public class HostBuilderCSharp : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a =>
                    a.UseStartup<Startup>()
                        .UseTestServer());
    }

    [MinColumn]
    [MaxColumn]
    public class Tests
    {
        private HttpClient fsharpHttpClient;
        private HttpClient csharpHttpClient;

        [GlobalSetup]
        public void Setup()
        {
            fsharpHttpClient = new HostBuilderFSharp().CreateClient();
            csharpHttpClient = new HostBuilderCSharp().CreateClient();
            
        }

        [Benchmark(Description = "FSharp Sum")]
        public async Task FSharpSum()
        {
            await fsharpHttpClient.GetAsync("http://localhost:5000/calculate?v1=1&Operation=plus&v2=5");
        }
        [Benchmark(Description = "CSharp Sum")]
        public async Task CSharpSum()
        {
            await csharpHttpClient.GetAsync("http://localhost:5001/calculator/calculate?value1=1&operation=plus&value2=5");
        } 
    }
}