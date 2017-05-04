namespace Parsing.AstNodes
{
    public class BinaryOperatorNode : ExpressionNode
    {
        public BinaryOperatorNode(ExpressionNode lhs, ExpressionNode rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public ExpressionNode Lhs { get; }

        public ExpressionNode Rhs { get; }
    }
}