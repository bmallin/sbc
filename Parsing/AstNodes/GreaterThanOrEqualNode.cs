namespace Parsing.AstNodes
{
    public class GreaterThanNodeOrEqual : BinaryOperatorNode
    {
        public GreaterThanNodeOrEqual(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}