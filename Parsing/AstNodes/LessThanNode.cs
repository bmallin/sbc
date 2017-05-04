namespace Parsing.AstNodes
{
    public class LessThanNode : BinaryOperatorNode
    {
        public LessThanNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}