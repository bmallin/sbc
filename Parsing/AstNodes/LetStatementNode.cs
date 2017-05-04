namespace Parsing.AstNodes
{
    public class LetStatementNode : StatementNode
    {
        public LetStatementNode(IdentifierNode lhs, ExpressionNode rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public IdentifierNode Lhs { get; }

        public ExpressionNode Rhs { get; }
    }
}