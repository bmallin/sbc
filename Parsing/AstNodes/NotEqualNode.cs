namespace Parsing.AstNodes
{
    public class NotEqualNode : BinaryOperatorNode
    {
        public NotEqualNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}