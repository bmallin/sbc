using Lexing.Tokens;

namespace Parsing.AstNodes
{
    public class IdentifierNode : ExpressionNode
    {
        public IdentifierNode(Token identifier)
        {
            Identifier = identifier;
        }

        public Token Identifier { get; }
    }
}