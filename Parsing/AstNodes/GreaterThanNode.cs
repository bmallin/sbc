namespace Parsing.AstNodes
{
    public class GreaterThanNode : BinaryOperatorNode
    {
        public GreaterThanNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}