namespace Parsing.AstNodes
{
    public class UnaryLogicalNegate : ExpressionNode
    {
        public ExpressionNode ToNegate { get; }

        public UnaryLogicalNegate(ExpressionNode toNegate)
        {
            ToNegate = toNegate;
        }
    }
}
