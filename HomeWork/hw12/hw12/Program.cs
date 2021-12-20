using BenchmarkDotNet.Running;

namespace hw12
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Tests>();
        }
    }
}