namespace Lexing.Tokens
{
    public class FloatLiteral : NumberLiteral
    {
        public float AsFloat => float.Parse(Value);

        public FloatLiteral(string value)
            : base(value)
        {
        }
    }
}
