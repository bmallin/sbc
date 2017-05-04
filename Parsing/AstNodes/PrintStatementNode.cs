using System.Collections.Generic;

namespace Parsing.AstNodes
{
    public class PrintStatementNode : StatementNode
    {
        public PrintStatementNode(List<ExpressionNode> expressions)
        {
            Expressions = expressions;
        }

        public List<ExpressionNode> Expressions { get; }
    }
}