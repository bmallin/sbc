namespace Parsing.AstNodes
{
    public abstract class Constant : ExpressionNode
    {
        public string Value { get; }

        protected Constant(string value)
        {
            Value = value;
        }
    }
}
