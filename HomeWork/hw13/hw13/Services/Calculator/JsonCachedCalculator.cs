using System;
using System.Linq;
using System.Threading;

namespace hw13.Services.Calculator
{
    public class JsonCachedCalculator
    {
        private readonly Calculator _calculator;
        private readonly JsonFileQueryable.JsonFileQueryable _jsonFileQueryable;

        public JsonCachedCalculator(Calculator calculator, JsonFileQueryable.JsonFileQueryable jsonFileQueryable)
        {
            _calculator = calculator;
            _jsonFileQueryable = jsonFileQueryable;
        }

        public double Calculate(string strExpression)
        {
            Thread.Sleep(1000);
            var cached = _jsonFileQueryable.FirstOrDefault(x => x["Expression"] == strExpression);
            if (cached != null) return Convert.ToDouble(cached["Result"]);

            var result = _calculator.Calculate(strExpression);
            return result;
        }
    }
}