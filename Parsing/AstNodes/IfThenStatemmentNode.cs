namespace Parsing.AstNodes
{
    public class IfThenStatemmentNode : StatementNode
    {
        public IfThenStatemmentNode(ExpressionNode predicate, StatementNode then)
        {
            Predicate = predicate;
            Then = then;
        }

        public ExpressionNode Predicate { get; }

        public StatementNode Then { get; }
    }
}