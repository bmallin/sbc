namespace Parsing.AstNodes
{
    public abstract class Constant : ExpressionNode
    {
        protected Constant(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}