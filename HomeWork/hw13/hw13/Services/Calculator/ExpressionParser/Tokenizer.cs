using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace hw13.Services.Calculator.ExpressionParser
{
    public class Tokenizer
    {
        public Tokenizer(TextReader reader)
        {
            _reader = reader;
            NextChar();
            NextToken();
        }

        private readonly TextReader _reader;
        private char _currentChar;
        private readonly char[] _delimiters = { '.', ',' };

        public Token Token { get; private set; }

        public double Number { get; private set; }

        private void NextChar()
        {
            var ch = _reader.Read();
            _currentChar = ch < 0 ? '\0' : (char)ch;
        }

        public void NextToken()
        {
            while (char.IsWhiteSpace(_currentChar)) NextChar();

            switch (_currentChar)
            {
                case '\0':
                    Token = Token.Eof;
                    return;

                case '+':
                    NextChar();
                    Token = Token.Add;
                    return;

                case '-':
                    NextChar();
                    Token = Token.Subtract;
                    return;

                case '*':
                    NextChar();
                    Token = Token.Multiply;
                    return;

                case '/':
                    NextChar();
                    Token = Token.Divide;
                    return;

                case '(':
                    NextChar();
                    Token = Token.OpenParens;
                    return;

                case ')':
                    NextChar();
                    Token = Token.CloseParens;
                    return;
            }

            if (char.IsDigit(_currentChar) || IsDelimiter(_currentChar))
            {
                var sb = new StringBuilder();
                var haveDecimalPoint = false;
                while (char.IsDigit(_currentChar) || !haveDecimalPoint && IsDelimiter(_currentChar))
                {
                    sb.Append(_currentChar);
                    haveDecimalPoint = IsDelimiter(_currentChar);
                    NextChar();
                }

                Number = double.Parse(sb.ToString(), CultureInfo.InvariantCulture);
                Token = Token.Number;
            }
        }

        private bool IsDelimiter(char val) => _delimiters.Contains(val);
    }
}