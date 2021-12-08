using System;
using hw10.Controllers.Calculator;
using hw10.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw10.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculate() => View();
        
        [HttpPost]
        public IActionResult Calculate([FromServices] ICalculator calculator,
            string str)
        {
            var expression = calculator.ParseStringToExpression(str);
            var result = calculator.GetExpressionResult(expression);
            return View(new CalculatorModel(result));
        }
    }
}