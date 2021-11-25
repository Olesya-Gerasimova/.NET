using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace hw9.Infrastructure
{
    public class Parser
    {
        private readonly Dictionary<char, Operator> _operators = new()
        {
            ['+'] = new() {Name = "+", Precedence = 1},
            ['-'] = new() {Name = "-", Precedence = 1},
            ['*'] = new() {Name = "*", Precedence = 2},
            ['/'] = new() {Name = "/", Precedence = 2}
        };

        private bool CompareOperators(Operator op1, Operator op2)
        {
            return op1.RightAssociative ? op1.Precedence < op2.Precedence : op1.Precedence <= op2.Precedence;
        }

        private bool CompareOperators(string op1, string op2) =>
            CompareOperators(_operators[Convert.ToChar(op1)], _operators[Convert.ToChar(op2)]);

        private IEnumerable<Token> Tokenize(string input)
        {
            var operatorsPattern = string.Join("", _operators.Select(op => $"\\{op.Key}"));
            var pattern = new Regex($"(?<Number>(((?<=[({operatorsPattern}]|^)-)?\\d*[,\\.]?\\d+))|" +
                                    $"(?<Operator>[{operatorsPattern}])|" +
                                    $"(?<Parenthesis>[()])");

            input = input.Replace(" ", "");

            foreach (Match m in pattern.Matches(input))
            {
                if (!string.IsNullOrEmpty(m.Groups["Number"].Value))
                {
                    yield return new Token(TokenType.Number, m.Groups["Number"].Value.Replace('.', ','));
                }
                else if (!string.IsNullOrEmpty(m.Groups["Operator"].Value))
                {
                    yield return new Token(TokenType.Operator, m.Groups["Operator"].Value);
                }
                else if (!string.IsNullOrEmpty(m.Groups["Parenthesis"].Value))
                {
                    yield return new Token(TokenType.Parenthesis, m.Groups["Parenthesis"].Value);
                }
            }
        }

        private IEnumerable<Token> ShuntingYard(IEnumerable<Token> tokens)
        {
            var opStack = new Stack<Token>();
            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                        yield return token;
                        break;
                    case TokenType.Operator:
                        while (opStack.TryPeek(out var peek) && peek.Type == TokenType.Operator &&
                               CompareOperators(token.Value, peek.Value))
                        {
                            yield return opStack.Pop();
                        }

                        opStack.Push(token);
                        break;
                    case TokenType.Parenthesis when token.Value == "(":
                        opStack.Push(token);
                        break;
                    case TokenType.Parenthesis when token.Value == ")":
                        while (opStack.TryPeek(out var prevToken) && prevToken.Value != "(")
                        {
                            yield return opStack.Pop();
                        }

                        if (opStack.TryPeek(out var openParenthesis) && openParenthesis.Value == "(")
                        {
                            opStack.Pop();
                        }
                        else
                        {
                            throw new ArgumentException("Mismatched parenthesis");
                        }

                        break;
                    default:
                        throw new Exception("Wrong token");
                }
            }

            while (opStack.Any())
            {
                var tok = opStack.Pop();
                if (tok.Type == TokenType.Parenthesis)
                    throw new Exception("Mismatched parenthesis");
                yield return tok;
            }
        }

        private Expression GetExpression(IEnumerable<Token> rpn)
        {
            var stack = new Stack<Expression>();
            foreach (var token in rpn)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                        stack.Push(Expression.Constant(double.Parse(token.Value.Replace(',', '.'), CultureInfo.InvariantCulture)));
                        break;
                    case TokenType.Operator:
                        if (stack.TryPop(out var right) && stack.TryPop(out var left))
                        {
                            switch (token.Value)
                            {
                                case "+":
                                    stack.Push(Expression.Add(left, right));
                                    break;
                                case "-":
                                    stack.Push(Expression.Subtract(left, right));
                                    break;
                                case "*":
                                    stack.Push(Expression.Multiply(left, right));
                                    break;
                                case "/":
                                    stack.Push(Expression.Divide(left, right));
                                    break;
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Not enough arguments");
                        }

                        break;
                }
            }

            if (stack.Count != 1)
            {
                throw new ArgumentException("Wrong rpn");
            }

            return stack.Pop();
        }

        public Expression ParseExpression(string input)
        {
            var tokens = Tokenize(input);
            var rpn = ShuntingYard(tokens);
            return GetExpression(rpn);
        }
    }
}