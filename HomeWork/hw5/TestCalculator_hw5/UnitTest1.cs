using Calculator_F_hw5;
using Xunit;

namespace TestCalculator_RCE
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("$", "+", "3", CalculatorOperations.NumbersErrorCode)]
        [InlineData("15", "-", "*", CalculatorOperations.NumbersErrorCode)]
        [InlineData("14", "bB", "2,1", CalculatorOperations.OperationErrorCode)]
        [InlineData("21", " ", "2.8", CalculatorOperations.OperationErrorCode)]
        [InlineData("14", " ", "3,2848", CalculatorOperations.OperationErrorCode)]
        public void TestMain_Method_ReturnErrorValue(string num1, string operation, string num2, int result)
        {
            var res = MyCalculator.getCodeForReturn(num1, operation, num2);

            Assert.Equal(res.ErrorValue, result);
        }

        [Theory]
        [InlineData("0.54314", "+", "5", CalculatorOperations.Ok_Code)]
        [InlineData("131313", "-", "13.131313", CalculatorOperations.Ok_Code)]
        [InlineData("24.2", "*", "4,5", CalculatorOperations.Ok_Code)]
        [InlineData("456", "-", "456", CalculatorOperations.Ok_Code)]
        [InlineData("18", "/", "9,0202", CalculatorOperations.Ok_Code)]
        public void TestMain_Method_ReturnValue(string num1, string operation, string num2, int result)
        {
            var res = MyCalculator.getCodeForReturn(num1, operation, num2);

            Assert.Equal(res.ResultValue, result);
        }


        [Theory]
        [InlineData("2", "+", "4", CalculatorOperations.Ok_Code)]
        [InlineData("12", "-", "4", CalculatorOperations.Ok_Code)]
        [InlineData("14", "-", "4,5", CalculatorOperations.Ok_Code)]
        [InlineData("27", "/", "3", CalculatorOperations.Ok_Code)]
        public void TestProces_ProcesMethod_ReturnResult(string num1, string operation, string num2, int result)
        {
            var code = MyCalculator.Proces(num1, operation, num2);

            Assert.Equal(code, result);
        }

        [Theory]
        [InlineData("1", "1", CalculatorOperations.Ok_Code)]
        [InlineData("2", "12", CalculatorOperations.Ok_Code)]
        [InlineData("2", "1212", CalculatorOperations.Ok_Code)]
        public void TestClaculator_AddMethod_ReturnSum(string num1, string num2, int result)
        {
            var re = MyCalculator.Add(num1, num2);

            Assert.Equal(re, result);
        }
    }
}