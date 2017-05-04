namespace Parsing.AstNodes
{
    public class DivisionNode : BinaryOperatorNode
    {
        public DivisionNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}