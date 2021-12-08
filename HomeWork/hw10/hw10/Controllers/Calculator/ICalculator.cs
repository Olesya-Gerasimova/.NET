using System.Linq.Expressions;

namespace hw10.Controllers.Calculator
{
    public interface ICalculator
    {
        Expression ParseStringToExpression(string str);
        string GetExpressionResult(Expression expression);
    }
}