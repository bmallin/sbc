namespace Lexing.Tokens
{
    public abstract class NumberLiteral : Token
    {
        protected NumberLiteral(string value)
            : base(value)
        {
        }
    }
}
