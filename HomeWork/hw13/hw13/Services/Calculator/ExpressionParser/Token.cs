namespace hw13.Services.Calculator.ExpressionParser
{
    public enum Token
    {
        Eof,
        Add,
        Subtract,
        Multiply,
        Divide,
        OpenParens,
        CloseParens,
        Number,
    }
}