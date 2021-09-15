using hw1;
using NUnit.Framework;

namespace hw1Test
{
    public class Tests
    {
        private CalculatorLauncher _calculatorLauncher;
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            _calculatorLauncher = new CalculatorLauncher();
        }

        [TestCase(-2, 6, 4)]
        [TestCase(2, 3, 5)]
        [TestCase(-4, -1, -5)]
        public void Test_Addition_Calculator(int first, int second, int expectedResult)
        {
            var calculated = _calculator.Calculate("+", first, second);
            Assert.AreEqual(expectedResult, calculated);
        }

        [TestCase(-1, 4, -5)]
        [TestCase(7, 9, -2)]
        [TestCase(-6, -3, -3)]
        public void Test_Minus_Calculator(int first, int second, int expectedResult)
        {
            var calculated = _calculator.Calculate("-", first, second);
            Assert.AreEqual(expectedResult, calculated);
        }

        [TestCase(-7, 2, -14)]
        [TestCase(3, 2, 6)]
        [TestCase(-1, -9, 9)]
        public void Test_Multiply_Calculator(int first, int second, int expectedResult)
        {
            var calculated = _calculator.Calculate("*", first, second);
            Assert.AreEqual(expectedResult, calculated);
        }

        [TestCase]
        public void Test_Incorrect_Operation_Calculator()
        {
            var calculated = _calculator.Calculate("T", 2, 2);
            Assert.AreEqual(0, calculated);
        }

        [TestCase(-14, 2, -7)]
        [TestCase(6, 2, 3)]
        [TestCase(-16, -8, 2)]
        public void Test_Divide_Calculator(int first, int second, int expectedResult)
        {
            var calculated = _calculator.Calculate("/", first, second);
            Assert.AreEqual(expectedResult, calculated);
        }

        [TestCase( new string[] { "2", "/", "2" }, 0)]
        [TestCase( new string[] { "2", "/", "2", "+", "1" }, 1)]
        [TestCase( new string[] { "a", "+", "a" }, 2)]
        public void CalculatorLauncher_Valid_Arguments(string[] args, int expectedExitCode)
        {
            var exitCode = _calculatorLauncher.Launch(args);
            Assert.AreEqual(expectedExitCode, exitCode);
        }

        [TestCase]
        public void CalculatorLauncher_Divide_By_Zero()
        {
            var exitCode = _calculatorLauncher.Launch(new[] {"2", "/", "0"});
            Assert.AreEqual(3,exitCode);
        }
        
    }
}