namespace Parsing.AstNodes
{
    public class LineNode : AstNode
    {
        public LineNode(int lineNumber, StatementNode statement)
        {
            LineNumber = lineNumber;
            Statement = statement;
        }

        public int LineNumber { get; }

        public StatementNode Statement { get; }
    }
}