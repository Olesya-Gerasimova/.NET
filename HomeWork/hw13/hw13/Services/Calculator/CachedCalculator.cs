using System.Linq;
using System.Threading;
using hw13.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace hw13.Services.Calculator
{
    public class CachedCalculator
    {
        private readonly Calculator _calculator;
        private readonly IMemoryCache _cache;

        public CachedCalculator(Calculator calculator, IMemoryCache cache)
        {
            _calculator = calculator;
            _cache = cache;
        }

        public double Calculate(string strExpression)
        {
            Thread.Sleep(1000);

            if (_cache.TryGetValue(strExpression, out double result))
                return result;

            result = _calculator.Calculate(strExpression);
            _cache.Set(strExpression, result);
            return result;
        }
    }
}