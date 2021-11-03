using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApp;

namespace WebAppTests
{
    public class TestClientProvider
    {
        public TestClientProvider()
        {
            var er = new WebApplicationFactory<Startup>();
            Client = er.CreateClient();
        }

        public HttpClient Client { get; }
    }
}