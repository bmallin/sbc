namespace Lexing.Tokens
{
    public class IntegerLiteral : NumberLiteral
    {
        public IntegerLiteral(string value)
            : base(value)
        {
        }

        public int AsInt => int.Parse(Value);
    }
}