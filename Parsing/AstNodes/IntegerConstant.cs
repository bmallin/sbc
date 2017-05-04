namespace Parsing.AstNodes
{
    public class IntegerConstant : Constant
    {
        public IntegerConstant(string value)
            : base(value)
        {
        }

        public int AsInt => int.Parse(Value);
    }
}