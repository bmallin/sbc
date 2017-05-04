namespace Parsing.AstNodes
{
    public class EqualNode : BinaryOperatorNode
    {
        public EqualNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}