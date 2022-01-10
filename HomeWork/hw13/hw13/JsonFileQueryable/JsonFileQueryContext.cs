using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace hw13.JsonFileQueryable
{
    public static class JsonFileQueryContext
    {
        internal static object Execute(Expression expression, bool isEnumerable, string jsonFilePath)
        {
            var queryableElements = GetJsonData(jsonFilePath); 

            var treeCopier = new ExpressionTreeModifier(queryableElements);
            var newExpressionTree = treeCopier.Visit(expression);

            return isEnumerable
                ? queryableElements.Provider.CreateQuery(newExpressionTree)
                : queryableElements.Provider.Execute(newExpressionTree);
        }

        private static IQueryable<Dictionary<string, string>> GetJsonData(string jsonFilePath)
        {
            var data = File.ReadAllText(jsonFilePath);
            var rows = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(data);
            return rows.AsQueryable();
        }
    }
}