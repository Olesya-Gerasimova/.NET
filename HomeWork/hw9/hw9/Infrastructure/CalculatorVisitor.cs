using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace hw9.Infrastructure
{
    public class CalculatorVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var left = Task.Run(() => Visit(node.Left));
            var right = Task.Run(() => Visit(node.Right));

            Thread.Sleep(1000);
            var t = Task.WhenAll(left, right);
            t.Wait();
            var leftVal = (double)(t.Result[0] as ConstantExpression)?.Value!;
            var rightVal = (double)(t.Result[1] as ConstantExpression)?.Value!;

            var result = node.NodeType switch
            {
                ExpressionType.Add => leftVal + rightVal,
                ExpressionType.Subtract => leftVal - rightVal,
                ExpressionType.Multiply => leftVal * rightVal,
                ExpressionType.Divide => leftVal / rightVal,
            };

            return Expression.Constant(result);
        }
    }
}