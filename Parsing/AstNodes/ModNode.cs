namespace Parsing.AstNodes
{
    public class ModNode : BinaryOperatorNode
    {
        public ModNode(ExpressionNode lhs, ExpressionNode rhs) 
            : base(lhs, rhs)
        {
        }
    }
}
