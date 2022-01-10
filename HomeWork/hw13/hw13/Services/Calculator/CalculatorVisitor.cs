using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw13.Services.Calculator
{
    public class CalculatorVisitor
    {
        public Expression<Func<double>> Calculate(Expression<Func<double>> expression)
            => Expression.Lambda<Func<double>>(Visit(expression.Body));

        private Expression Visit(Expression expression) => Visit((dynamic)expression);

        private Expression Visit(BinaryExpression node)
        {
            var leftNodeTask = Task.Run(() => Visit(node.Left));
            var rightNodeTask = Task.Run(() => Visit(node.Right));
            Task.WhenAll(leftNodeTask, rightNodeTask);
            var leftNode = (double)((leftNodeTask.Result as ConstantExpression)?.Value
                                    ?? throw new InvalidOperationException($"Error while visiting {node.Left} expr"));
            var rightNode = (double)((rightNodeTask.Result as ConstantExpression)?.Value
                                     ?? throw new InvalidOperationException($"Error while visiting {node.Right} expr"));

            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftNode + rightNode, typeof(double)),
                ExpressionType.Subtract => Expression.Constant(leftNode - rightNode, typeof(double)),
                ExpressionType.Multiply => Expression.Constant(leftNode * rightNode, typeof(double)),
                ExpressionType.Divide => Expression.Constant(leftNode / rightNode, typeof(double)),
                _ => throw new NotSupportedException($"{node.NodeType} expression is not supported")
            };
        }

        private Expression Visit(UnaryExpression node)
        {
            if (node.NodeType != ExpressionType.Negate)
                throw new NotSupportedException($"{node.NodeType} expression is not supported");

            var value = (double)((Visit(node.Operand) as ConstantExpression)?.Value
                                 ?? throw new InvalidOperationException($"Error while visiting {node.Operand} expr"));
            return Expression.Constant(-value);
        }

        private Expression Visit(ConstantExpression node) => node;
    }
}