namespace Parsing.AstNodes
{
    public class MultiplicationNode : BinaryOperatorNode
    {
        public MultiplicationNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}