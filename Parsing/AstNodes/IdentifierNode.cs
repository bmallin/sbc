using Lexing.Tokens;

namespace Parsing.AstNodes
{
    public class IdentifierNode : ExpressionNode
    {
        public Token Identifier { get; }

        public IdentifierNode(Token identifier)
        {
            Identifier = identifier;
        }
    }
}
