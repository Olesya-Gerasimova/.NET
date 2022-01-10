using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace hw13.JsonFileQueryable
{
    public class JsonFileQueryable : IOrderedQueryable<Dictionary<string, string>>
    {
        public JsonFileQueryable(string jsonFilePath)
        {
            Provider = new JsonFileQueryProvider(jsonFilePath);
            Expression = Expression.Constant(this);
        }

        internal JsonFileQueryable(IQueryProvider provider, Expression expression)
        {
            Provider = provider;
            Expression = expression;
        }

        public IEnumerator<Dictionary<string, string>> GetEnumerator() =>
            Provider.Execute<IEnumerable<Dictionary<string, string>>>(Expression).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => typeof(Dictionary<string, string>);
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }
    }
}