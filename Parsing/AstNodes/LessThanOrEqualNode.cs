namespace Parsing.AstNodes
{
    public class LessThanOrEqualNode : BinaryOperatorNode
    {
        public LessThanOrEqualNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}