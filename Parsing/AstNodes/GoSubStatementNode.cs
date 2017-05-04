namespace Parsing.AstNodes
{
    public class GoSubStatementNode : StatementNode
    {
        public ExpressionNode JumpLocation { get; }

        public GoSubStatementNode(ExpressionNode jumpLocation)
        {
            JumpLocation = jumpLocation;
        }
    }
}
