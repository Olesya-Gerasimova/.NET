using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace hw13.JsonFileQueryable
{
    internal class ExpressionTreeModifier : ExpressionVisitor
    {
        private readonly IQueryable<Dictionary<string, string>> _fileSystemElements;

        internal ExpressionTreeModifier(IQueryable<Dictionary<string, string>> elements)
        {
            _fileSystemElements = elements;
        }

        protected override Expression VisitConstant(ConstantExpression c) =>
            c.Type == typeof(JsonFileQueryable)
                ? Expression.Constant(_fileSystemElements)
                : c;
    }
}