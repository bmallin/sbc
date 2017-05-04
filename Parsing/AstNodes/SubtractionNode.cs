namespace Parsing.AstNodes
{
    public class SubtractionNode : BinaryOperatorNode
    {
        public SubtractionNode(ExpressionNode lhs, ExpressionNode rhs)
            : base(lhs, rhs)
        {
        }
    }
}