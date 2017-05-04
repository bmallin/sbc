namespace Parsing.AstNodes
{
    public class GotoStatementNode : StatementNode
    {
        public GotoStatementNode(ExpressionNode jumpTarget)
        {
            JumpTarget = jumpTarget;
        }

        public ExpressionNode JumpTarget { get; }
    }
}