namespace Parsing.AstNodes
{
    public class AndNode : BinaryOperatorNode
    {
        public AndNode(ExpressionNode lhs, ExpressionNode rhs) 
            : base(lhs, rhs)
        {
        }
    }
}
