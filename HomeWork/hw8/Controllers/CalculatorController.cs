using Homework8.Interface;
using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
	public class CalculatorController : Controller
	{
		public double Add([FromServices] ICalculator calculator, double val1, double val2)
		{
			return calculator.Add(val1, val2);
		}

		public double Subtract([FromServices] ICalculator calculator, double val1, double val2)
		{
			return calculator.Subtract(val1, val2);
		}

		public double Divide([FromServices] ICalculator calculator, double val1, double val2)
		{
			return calculator.Divide(val1, val2);
		}

		public double Multiply([FromServices] ICalculator calculator, double val1, double val2)
		{
			return calculator.Multiply(val1, val2);
		}
	}
}