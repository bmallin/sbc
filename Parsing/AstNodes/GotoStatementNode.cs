namespace Parsing.AstNodes
{
    public class GotoStatementNode : StatementNode
    {
        public ExpressionNode JumpTarget { get; }

        public GotoStatementNode(ExpressionNode jumpTarget)
        {
            JumpTarget = jumpTarget;
        }
    }
}
