using System;
using hw13.Services.Calculator.ExpressionParser;

namespace hw13.Services.Calculator
{
    public class Calculator
    {
        private readonly ExceptionHandler<Calculator> _exceptionHandler;

        public Calculator(ExceptionHandler<Calculator> exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public double Calculate(string strExpression)
        {
            try
            {
                var parsedExpression = Parser.Parse(strExpression);
                var calculatorVisitor = new CalculatorVisitor();
                var calculated = calculatorVisitor.Calculate(parsedExpression);
                return calculated.Compile().Invoke();
            }
            catch (Exception e)
            {
                _exceptionHandler.HandleException(e);
                throw;
            }
        }
    }
}