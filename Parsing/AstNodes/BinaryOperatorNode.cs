namespace Parsing.AstNodes
{
    public class BinaryOperatorNode : ExpressionNode
    {
        public ExpressionNode Lhs { get; }

        public ExpressionNode Rhs { get; }

        public BinaryOperatorNode(ExpressionNode lhs, ExpressionNode rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }
    }
}
