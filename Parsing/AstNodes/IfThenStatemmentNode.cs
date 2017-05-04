namespace Parsing.AstNodes
{
    public class IfThenStatemmentNode : StatementNode
    {
        public ExpressionNode Predicate { get; }

        public StatementNode Then { get; }

        public IfThenStatemmentNode(ExpressionNode predicate, StatementNode then)
        {
            Predicate = predicate;
            Then = then;
        }
    }
}
