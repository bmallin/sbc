namespace Parsing.AstNodes
{
    public class FloatConstant : Constant
    {
        public float AsFloat => float.Parse(Value);

        public FloatConstant(string value) 
            : base(value)
        {
        }
    }
}
