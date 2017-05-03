using Lexing.Tokens;

namespace Parsing.AstNodes
{
    public class LetStatementNode : StatementNode
    {
        public IdentifierNode Lhs { get; }

        public ExpressionNode Rhs { get; }

        public LetStatementNode(IdentifierNode lhs, ExpressionNode rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }
    }
}
