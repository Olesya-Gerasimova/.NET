using System.Threading.Tasks;
using hw13.Services.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace hw13.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CachedCalculator _calculator;
        private readonly JsonCachedCalculator _jsonCachedCalculator;

        public CalculatorController(CachedCalculator calculator, JsonCachedCalculator jsonCachedCalculator)
        {
            _calculator = calculator;
            _jsonCachedCalculator = jsonCachedCalculator;
        }

        [HttpGet]
        public double Get(string request) => _calculator.Calculate(request);

        [HttpGet("JsonCached")]
        public double GetJsonCached(string request) => _jsonCachedCalculator.Calculate(request);
    }
}