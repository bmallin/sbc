namespace Parsing.AstNodes
{
    public class OrNode : BinaryOperatorNode
    {
        public OrNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}