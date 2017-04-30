namespace Lexing.Tokens
{
    public abstract class Token
    {
        public string Value { get; }

        protected Token(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"<{GetType().Name}>{Value}</{GetType().Name}>";
        }
    }
}
