using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using hw9.Infrastructure;

namespace hw11.Infrastructure
{
    public class DynamicCalculatorVisitor : ICalculatorVisitor
    {
        public Expression Visit(Expression node)
        {
            return Visit((dynamic) node);
        }

        private Expression Visit(BinaryExpression binaryExpression)
        {
            Thread.Sleep(1000);

            var left = Task.Run(() => Visit(binaryExpression.Left));
            var right = Task.Run(() => Visit(binaryExpression.Right));

            var t = Task.WhenAll(left, right);
            t.Wait();
            var leftVal = (double)(t.Result[0] as ConstantExpression)?.Value!;
            var rightVal = (double)(t.Result[1] as ConstantExpression)?.Value!;

            var result = binaryExpression.NodeType switch
            {
                ExpressionType.Add => leftVal + rightVal,
                ExpressionType.Subtract => leftVal - rightVal,
                ExpressionType.Multiply => leftVal * rightVal,
                ExpressionType.Divide => leftVal / rightVal,
                _ => throw new ArgumentOutOfRangeException(nameof(binaryExpression))
            };

            return Expression.Constant(result);
        }

        private Expression Visit(ConstantExpression constantExpression)
        {
            return constantExpression;
        }
    }
}