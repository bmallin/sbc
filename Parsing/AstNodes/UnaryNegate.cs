namespace Parsing.AstNodes
{
    public class UnaryNegate : ExpressionNode
    {
        public ExpressionNode ToNegate { get; }

        public UnaryNegate(ExpressionNode toNegate)
        {
            ToNegate = toNegate;
        }
    }
}
