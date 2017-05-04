namespace Lexing.Tokens
{
    public abstract class Symbol : Token
    {
        protected Symbol(string value)
            : base(value)
        {
        }
    }
}