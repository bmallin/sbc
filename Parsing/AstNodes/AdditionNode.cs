namespace Parsing.AstNodes
{
    public class AdditionNode : BinaryOperatorNode
    {
        public AdditionNode(ExpressionNode lhs, ExpressionNode rhs) 
            : base(lhs, rhs)
        {
        }
    }
}
