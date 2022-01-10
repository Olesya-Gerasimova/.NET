using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using hw13;
using JetBrains.dotMemoryUnit;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class DotMemoryUnit : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _output;

        public DotMemoryUnit(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = output;
            DotMemoryUnitTestOutput.SetOutputMethod(_output.WriteLine);
        }
        
        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = true,CollectAllocations = true)]
        public /*async Task*/ void Test()
        {
            // Arrange
            const int count = 10 * 1000 * 1000;
            const int x = 100;
            //const int count = 100;
            //const int x = 10;
            
            //var client = _factory.CreateClient();
            
            var byteCount = 0L;
            var start = dotMemory.Check();
            
            
            // Act
            for (var i = 0; i < count/x; i+= x)
            {
                //var requests = new Task[x];
                for (var j = 0; j < x; j++)
                {
                    var expr = $"{i} + {j}";
                    byteCount += expr.Length * sizeof(char);
                    //var encoded = UrlEncoder.Create().Encode(expr);
                    //var url = $"/Calculator?request={encoded}";
                    //requests[j] = client.GetAsync(url);
                }
                //Task.WaitAll(requests);
            }
            

            // Assert
            dotMemory.Check(
                mem =>
                {
                    var actualBytes = mem.GetTrafficFrom(start).CollectedMemory.SizeInBytes;
                    _output.WriteLine($"Actual bytes: {actualBytes.ToString()}");
                    _output.WriteLine($"Expected bytes: {byteCount.ToString()}");
                    Assert.True(actualBytes >= byteCount);
                });
        }
    }
}