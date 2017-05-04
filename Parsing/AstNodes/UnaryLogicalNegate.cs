namespace Parsing.AstNodes
{
    public class UnaryLogicalNegate : ExpressionNode
    {
        public UnaryLogicalNegate(ExpressionNode toNegate)
        {
            ToNegate = toNegate;
        }

        public ExpressionNode ToNegate { get; }
    }
}