using System;
using System.IO;
using System.Linq.Expressions;

namespace hw13.Services.Calculator.ExpressionParser
{
    public class Parser
    {
        private readonly Tokenizer _tokenizer;
        private Parser(Tokenizer tokenizer) => _tokenizer = tokenizer;

        public static Expression<Func<double>> Parse(string str)
        {
            var tokenizer = new Tokenizer(new StringReader(str));
            var parser = new Parser(tokenizer);
            var expr = parser.ParseExpression();
            var lambda = Expression.Lambda<Func<double>>(expr);
            return lambda;
        }

        private Expression ParseExpression()
        {
            var expr = ParseAddSubtract();

            if (_tokenizer.Token != Token.Eof)
                throw new ArgumentException("Unexpected characters in the end of expression");

            return expr;
        }

        private Expression ParseAddSubtract()
        {
            var lhs = ParseMultiplyDivide();

            while (true)
            {
                switch (_tokenizer.Token)
                {
                    case Token.Add:
                    {
                        _tokenizer.NextToken();
                        var rhs = ParseMultiplyDivide();
                        lhs = Expression.Add(lhs, rhs);
                        break;
                    }
                    case Token.Subtract:
                    {
                        _tokenizer.NextToken();
                        var rhs = ParseMultiplyDivide();
                        lhs = Expression.Subtract(lhs, rhs);
                        break;
                    }
                    default: return lhs;
                }
            }
        }

        private Expression ParseMultiplyDivide()
        {
            var lhs = ParseUnary();

            while (true)
            {
                switch (_tokenizer.Token)
                {
                    case Token.Multiply:
                    {
                        _tokenizer.NextToken();
                        var rhs = ParseUnary();
                        lhs = Expression.Multiply(lhs, rhs);
                        break;
                    }
                    case Token.Divide:
                    {
                        _tokenizer.NextToken();
                        var rhs = ParseUnary();
                        lhs = Expression.Divide(lhs, rhs);
                        break;
                    }
                    default: return lhs;
                }
            }
        }


        private Expression ParseUnary()
        {
            while (true)
            {
                switch (_tokenizer.Token)
                {
                    case Token.Add:
                        _tokenizer.NextToken();
                        continue;
                    case Token.Subtract:
                    {
                        _tokenizer.NextToken();

                        var rhs = ParseUnary();

                        return Expression.Negate(rhs);
                    }
                    default:
                        return ParseLeaf();
                }
            }
        }

        private Expression ParseLeaf()
        {
            switch (_tokenizer.Token)
            {
                case Token.Number:
                {
                    var node = Expression.Constant(_tokenizer.Number);
                    _tokenizer.NextToken();
                    return node;
                }
                case Token.OpenParens:
                {
                    _tokenizer.NextToken();

                    var node = ParseAddSubtract();

                    if (_tokenizer.Token != Token.CloseParens)
                        throw new ArgumentException("No close parenthesis found");
                    _tokenizer.NextToken();

                    return node;
                }
                default:
                    throw new ArgumentException($"Unexpected token: {_tokenizer.Token}");
            }
        }
    }
}