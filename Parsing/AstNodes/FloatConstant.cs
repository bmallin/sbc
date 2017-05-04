namespace Parsing.AstNodes
{
    public class FloatConstant : Constant
    {
        public FloatConstant(string value)
            : base(value)
        {
        }

        public float AsFloat => float.Parse(Value);
    }
}