using System.Collections.Generic;

namespace Parsing.AstNodes
{
    public class PrintStatementNode : StatementNode
    {
        public List<ExpressionNode> Expressions { get; }

        public PrintStatementNode(List<ExpressionNode> expressions)
        {
            Expressions = expressions;
        }
    }
}
