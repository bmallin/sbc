namespace Parsing.AstNodes
{
    public class UnaryNegate : ExpressionNode
    {
        public UnaryNegate(ExpressionNode toNegate)
        {
            ToNegate = toNegate;
        }

        public ExpressionNode ToNegate { get; }
    }
}