using System.Linq.Expressions;

namespace hw9.Infrastructure
{
    public class Calculator
    {
        public double Calculate(string input)
        {
            var parser = new Parser();
            var expression = parser.ParseExpression(input);
            return (double) (new CalculatorVisitor().Visit(expression) as ConstantExpression)?.Value!;
        }
    }
}