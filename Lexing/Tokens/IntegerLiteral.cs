namespace Lexing.Tokens
{
    public class IntegerLiteral : NumberLiteral
    {
        public int AsInt => int.Parse(Value);

        public IntegerLiteral(string value)
            : base(value)
        {
        }
    }
}
