using System.Data.Common;
using hw10.DbModels;
using hw10.Services;
using hw10.Services.Calculator;
using Expression = System.Linq.Expressions.Expression;

namespace hw10.Controllers.Calculator
{
    public class CacheCalculatorDecorator : CalculatorDecorator
    {
        private readonly ExpressionCacheService _expressionCacheService;

        public CacheCalculatorDecorator(ICalculator calculator, ExpressionCacheService expressionCacheService) :
            base(calculator)
        {
            _expressionCacheService = expressionCacheService;
        }

        public override string GetExpressionResult(Expression expression)
        {
            var cachedExpression = _expressionCacheService.Get(expression);
            if (cachedExpression != null)
                return cachedExpression.ExpressionResult;
            var result = Calculator.GetExpressionResult(expression);
            _expressionCacheService.Add(new ExpressionModel
                {ExpressionValue = expression.ToString(), ExpressionResult = result});
            return result;
        }
    }
}