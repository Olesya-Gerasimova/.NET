using Xunit;

namespace hw8.Tests
{
	public class CalculatorTests
	{
		private static readonly NumericalCalculator calculator = new();
		
		[Theory]
		[InlineData(1, 2, 3)]
		[InlineData(-2, 3, 1)]
		[InlineData(2, -4, -2)]
		[InlineData(-3, -4, -7)]
		public void Add_AddTwoNumbers_ReturnSum(
			int firstNum, int secondNum, int expected)
		{
			var actual = calculator.Add(firstNum, secondNum);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(5, 2, 3)]
		[InlineData(2, -6, 8)]
		[InlineData(-3, 4, -7)]
		[InlineData(-8, -2, -6)]
		public void Subtract_ReturnDifference(
			int firstNum, int secondNum, int expected)
		{
			var actual = calculator.Subtract(firstNum, secondNum);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, -6, 0)]
		[InlineData(4, 0, 0)]
		[InlineData(1, 20, 20)]
		[InlineData(3, -2, -6)]
		[InlineData(-5, -3, 15)]
		public void Multiply_ReturnProduct(
			int firstNum, int secondNum, int expected)
		{
			var actual = calculator.Multiply(firstNum, secondNum);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(20, 2, 10)]
		[InlineData(10, -5, -2)]
		[InlineData(-9, -9, 1)]
		[InlineData(0, 2, 0)]
		[InlineData(0, -10, 0)]
		[InlineData(12, 0, 0)]
		[InlineData(0, 0, 0)]
		public void Divide_ReturnQuotient(
			int firstNum, int secondNum, int expected)
		{
			var actual = calculator.Divide(firstNum, secondNum);
			Assert.Equal(expected, actual);
		}
	}
}