using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using hw10.DbModels;
using WebApplication;

namespace hw10.Services.Calculator
{
    public class ExpressionCacheService
    {
        private readonly ApplicationContext context;

        public ExpressionCacheService(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(ExpressionModel expressionModel)
        {
            context.Expressions.Add(expressionModel);
            context.SaveChanges();
        }

        public ExpressionModel Get(Expression expressionModel)
        {
            Thread.Sleep(1000);
            var expressionValue = expressionModel.ToString();
            return context.Expressions?.FirstOrDefault(expr => expr.ExpressionValue == expressionValue);
        }
    }
}