namespace Parsing.AstNodes
{
    public class GoSubStatementNode : StatementNode
    {
        public GoSubStatementNode(ExpressionNode jumpLocation)
        {
            JumpLocation = jumpLocation;
        }

        public ExpressionNode JumpLocation { get; }
    }
}