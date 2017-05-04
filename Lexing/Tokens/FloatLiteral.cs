namespace Lexing.Tokens
{
    public class FloatLiteral : NumberLiteral
    {
        public FloatLiteral(string value)
            : base(value)
        {
        }

        public float AsFloat => float.Parse(Value);
    }
}