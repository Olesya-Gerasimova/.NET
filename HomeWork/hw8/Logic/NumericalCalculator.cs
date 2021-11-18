using hw8.Interface;

namespace hw8
{
	public class NumericalCalculator : ICalculator
	{
		public double Add(double firstValue, double secondValue)
			=> firstValue + secondValue;

		public double Subtract(double firstValue, double secondValue)
			=> firstValue - secondValue;

		public double Divide(double firstValue, double secondValue)
			=> secondValue == 0 ? 0 : firstValue / secondValue;

		public double Multiply(double firstValue, double secondValue)
			=> firstValue * secondValue;
	}
}