namespace Parsing.AstNodes
{
    public class IntegerConstant : Constant
    {
        public int AsInt => int.Parse(Value);

        public IntegerConstant(string value) 
            : base(value)
        {
        }
    }
}
