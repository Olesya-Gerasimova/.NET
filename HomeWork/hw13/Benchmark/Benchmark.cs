using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using hw13;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Benchmark
{
    /*public class CSharpHostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x => { x.UseStartup<Startup>().UseTestServer(); });
            return builder;
        }
    }
    
    public class Benchmark
    {
        private HttpClient _cSharpClient;

        [GlobalSetup]
        public void SetUp()
        {
            _cSharpClient =  new CSharpHostBuilder().CreateClient();
        }

        [Benchmark]
        public async Task TestCSharp()
        {
            var url = $"/Calculator?request={15}+{'/'}+{5}";
            await _cSharpClient.GetAsync(url);
        }
        
        [Benchmark]
        public async Task TestCSharp()
        {
            var url = $"/Calculator?request={15}+{'/'}+{5}";
            await _cSharpClient.GetAsync(url);
        }
    }*/
    
    public class Methods
    {
        public int DoSimple(int a) => a + a;

        public virtual int DoVirtual(int a) => a + a;

        public static int DoStatic(int a) => a + a;

        public T DoGeneric<T>(T a) => a;

        public dynamic DoDynamic(dynamic a) => a + a;

        public int ReflectionMethod(int a) => a + a;
    }
    
    public class Benchmark
    {
        private Methods _methods;
        private int _argument;
        private static MethodInfo _reflectionMethod;

        [GlobalSetup]
        public void Setup()
        {
            _methods = new Methods();
            _reflectionMethod = typeof(Methods).GetMethod("DoReflection");
            _argument = 10;
        }

        [Benchmark(Description = "DoSimple")]
        public void TestSimpleMethod() => _methods.DoSimple(_argument);

        [Benchmark(Description = "DoVirtual")]
        public void TestVirtualMethod() => _methods.DoVirtual(_argument);

        [Benchmark(Description = "DoStatic")]
        public void TestStaticMethod() => Methods.DoStatic(_argument);

        [Benchmark(Description = "DoGeneric")]
        public void TestGenericMethod() => _methods.DoGeneric(_argument);

        [Benchmark(Description = "DoDynamic")]
        public void TestDynamicMethod() => _methods.DoDynamic(_argument);

        [Benchmark(Description = "DoReflection")]
        public void TestReflectionMethod() => _reflectionMethod.Invoke(_methods, new object[] {_argument});
    }
}