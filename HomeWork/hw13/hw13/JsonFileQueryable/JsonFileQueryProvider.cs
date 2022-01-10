using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace hw13.JsonFileQueryable
{
    public class JsonFileQueryProvider : IQueryProvider
    {
        private readonly string _jsonFilePath;

        public JsonFileQueryProvider(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public IQueryable CreateQuery(Expression expression) => new JsonFileQueryable(this, expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) =>
            (IQueryable<TElement>)new JsonFileQueryable(this, expression);

        public object Execute(Expression expression) => Execute<Dictionary<string, string>>(expression);

        public TResult Execute<TResult>(Expression expression)
        {
            var isEnumerable = typeof(TResult).Name == "IEnumerable`1";
            return (TResult)JsonFileQueryContext.Execute(expression, isEnumerable, _jsonFilePath);
        }
    }
}