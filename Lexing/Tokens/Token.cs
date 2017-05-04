namespace Lexing.Tokens
{
    public abstract class Token
    {
        protected Token(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"<{GetType().Name}>{Value}</{GetType().Name}>";
        }
    }
}