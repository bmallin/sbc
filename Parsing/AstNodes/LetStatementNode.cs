using Lexing.Tokens;

namespace Parsing.AstNodes
{
    public class LetStatementNode : StatementNode
    {
        public Identifier Lhs { get; }

        public ExpressionNode Rhs { get; }

        public LetStatementNode(Identifier lhs, ExpressionNode rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }
    }
}
