using System;

namespace hw1
{
    public class CalculatorLauncher
    {
        private const int WrongArgumentLength = 1;
        private const int WrongArgFormat = 2;

        public int Launch(string[] args)
        {
            if (CheckArgLength(args))
            {
                return WrongArgumentLength;
            }

            var operation = args[1];
            if (TryParseOrQuit(args[0], out var val1)
                || TryParseOrQuit(args[2], out var val2))
            {
                return WrongArgFormat;
            }

            var result = new Calculator().Calculate(operation, val1, val2);

            Console.WriteLine($"Result is: {result}");
            return 0;
        }

        private static bool TryParseOrQuit(string arg, out int val1)
        {
            var isVal1 = int.TryParse(arg, out val1);
            if (isVal1)
            {
                return false;
            }

            Console.WriteLine($"Value is not int: {arg}");
            {
                return true;
            }

        }

        private static bool CheckArgLength(string[] args)
        {
            if (args.Length >= 3)
            {
                return false;
            }

            Console.WriteLine(
                $"The program requires 3 "
                + $"CLI arguments but {args.Length} provided");
            {
                return true;
            }
        }
    }
}