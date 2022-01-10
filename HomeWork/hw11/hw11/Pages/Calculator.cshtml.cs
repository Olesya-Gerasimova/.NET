using System;
using System.Globalization;
using hw11.Infrastructure.Interfaces;
using hw9.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace hw11.Pages
{
    public class Calculator : PageModel
    {
        private readonly ICalculator _calculator;
        private readonly IExceptionHandler _exceptionHandler;

        public Calculator(ICalculator calculator, IExceptionHandler exceptionHandler)
        {
            _calculator = calculator;
            _exceptionHandler = exceptionHandler;
        }

        public IActionResult OnGet(string expression)
        {
            try
            {
                var result = _calculator.Calculate(expression);
                return Content(result.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                _exceptionHandler.HandleException(e, LogLevel.Information);
                return Content(e.Message);
            }
        }
    }
}