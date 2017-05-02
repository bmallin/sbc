namespace Parsing.AstNodes
{
    public class LineNode : AstNode
    {
        public int LineNumber { get; }

        public StatementNode Statement { get; }

        public LineNode(int lineNumber, StatementNode statement)
        {
            LineNumber = lineNumber;
            Statement = statement;
        }
    }
}
