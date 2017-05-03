  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Lexing;
  using Lexing.Tokens;
  using Parsing.AstNodes;

namespace Parsing
{
    public class Parser
    {
        private readonly TokenReader _reader;

        public Parser(TokenReader reader)
        {
            _reader = reader;
        }

        public AstNode BuildAst()
        {
            return ParseProgram();
        }

        private T Match<T>() where T : Token
        {
            if (!(_reader.Peek() is T))
                throw new Exception($"Expected token of type {typeof(T).Name} but got {_reader.Peek().GetType().Name}");

            return (T) _reader.Read();
        }

        private Token Match(params Type[] types)
        {
            if (types.All(t => _reader.Peek().GetType() != t))
            {
                var expected = string.Join(", ", types.Select(t => t.Name));
                throw new Exception($"Expected token of type {expected} but got {_reader.Peek().GetType().Name}");
            }

            return _reader.Read();
        }

        private ProgramNode ParseProgram()
        {
            return new ProgramNode(ParseLines());
        }

        private List<LineNode> ParseLines()
        {
            var lines = new List<LineNode>();
            while (!_reader.EndOfStream)
            {
                lines.Add(ParseLine());
            }

            return lines;
        }

        private LineNode ParseLine()
        {
            var lineNumber = Match<IntegerLiteral>().AsInt;
            var statement = ParseStatement();

            if (statement is EndStatementNode)
            {
                if (_reader.Peek() is LineTerminator)
                    Match<LineTerminator>();
            }
            else
            {
                Match<LineTerminator>();
            }

            return new LineNode(lineNumber, statement);
        }

        private StatementNode ParseStatement()
        {
            var statementIdent = Match<Identifier>();

            switch (statementIdent.Value.ToLower())
            {
                case "let":
                    return ParseLetStatement();
                case "print":
                    return ParsePrintStatement();
                case "end":
                    return new EndStatementNode();
                default:
                    throw new Exception($"Unexpected statement: {statementIdent.Value}");
            }
        }

        private LetStatementNode ParseLetStatement()
        {
            var lhsToken = Match<Identifier>();
            Match<Assign>();

            var lhs = new IdentifierNode(lhsToken);
            var rhs = ParseExpression();

            return new LetStatementNode(lhs, rhs);
        }

        private PrintStatementNode ParsePrintStatement()
        {
            var expressions = new List<ExpressionNode> {ParseExpression()};

            while (_reader.Peek() is Comma)
            {
                Match<Comma>();
                expressions.Add(ParseExpression());
            }

            return new PrintStatementNode(expressions);
        }

        private ExpressionNode ParseExpression()
        {
            var lhs = ParseJoin();

            while (_reader.Peek() is Or)
            {
                lhs = new OrNode(lhs, ParseJoin());
            }

            return lhs;
        }

        private ExpressionNode ParseJoin()
        {
            var lhs = ParseEquality();

            while (_reader.Peek() is And)
            {
                Match<And>();
                lhs = new AndNode(lhs, ParseEquality());
            }

            return lhs;
        }

        private ExpressionNode ParseEquality()
        {
            var lhs = ParseRel();

            while (_reader.Peek() is Equal || _reader.Peek() is NotEqual)
            {
                var token = Match(typeof(Equal), typeof(NotEqual));
                if (token is Equal)
                {
                    lhs = new EqualNode(lhs, ParseRel());
                }
                else
                {
                    lhs = new NotEqualNode(lhs, ParseRel());
                }
            }

            return lhs;
        }

        private ExpressionNode ParseRel()
        {
            var lhs = ParseMathExpr();

            if (_reader.Peek() is LessThan)
            {
                Match<LessThan>();
                lhs = new LessThanNode(lhs, ParseMathExpr());
            }
            else if (_reader.Peek() is LessThanOrEqual)
            {
                Match<LessThanOrEqual>();
                lhs = new LessThanOrEqualNode(lhs, ParseMathExpr());
            }
            else if (_reader.Peek() is GreaterThan)
            {
                Match<GreaterThan>();
                lhs = new GreaterThanNode(lhs, ParseMathExpr());
            }
            else if (_reader.Peek() is GreaterThanOrEqual)
            {
                Match<GreaterThanOrEqual>();
                lhs = new GreaterThanNodeOrEqual(lhs, ParseMathExpr());
            }

            return lhs;
        }

        private ExpressionNode ParseMathExpr()
        {
            var lhs = ParseTerm();

            while (true)
            {
                if (_reader.Peek() is Plus)
                {
                    Match<Plus>();
                    lhs = new AdditionNode(lhs, ParseTerm());
                }
                else if (_reader.Peek() is Dash)
                {
                    Match<Dash>();
                    lhs = new SubtractionNode(lhs, ParseTerm());
                }
                else
                {
                    break;
                }
            }

            return lhs;
        }

        private ExpressionNode ParseTerm()
        {
            var lhs = ParseUnary();

            while (true)
            {
                if (_reader.Peek() is Asterisk)
                {
                    Match<Asterisk>();
                    lhs = new MultiplicationNode(lhs, ParseUnary());
                }
                else if (_reader.Peek() is Slash)
                {
                    Match<Slash>();
                    lhs = new DivisionNode(lhs, ParseUnary());
                }
                else if (_reader.Peek() is Percent)
                {
                    Match<Percent>();
                    lhs = new ModNode(lhs, ParseUnary());
                }
                else
                {
                    break;
                }
            }

            return lhs;
        }

        private ExpressionNode ParseUnary()
        {
            if (_reader.Peek() is Dash)
            {
                Match<Dash>();
                return new UnaryNegate(ParseUnary());
            }
            if (_reader.Peek() is Bang)
            {
                Match<Bang>();
                return new UnaryLogicalNegate(ParseUnary());
            }
            if (_reader.Peek() is Plus)
            {
                Match<Plus>();
                // we don't actually need to do anything else here.
            }

            return ParseFactor();
        }

        private ExpressionNode ParseFactor()
        {
            ExpressionNode x;
            if (_reader.Peek() is LeftParen)
            {
                Match<LeftParen>();
                x = ParseExpression();
                Match<RightParen>();

                return x;
            }

            if (_reader.Peek() is IntegerLiteral)
            {
                var token = Match<IntegerLiteral>();
                x = new IntegerConstant(token.Value);
                return x;
            }

            if (_reader.Peek() is FloatLiteral)
            {
                var token = Match<FloatLiteral>();
                x = new FloatConstant(token.Value);
                return x;
            }

            if (_reader.Peek() is StringLiteral)
            {
                var token = Match<StringLiteral>();
                x = new StringConstant(token.Value);
                return x;
            }

            if (_reader.Peek() is True)
            {
                Match<True>();
                x = BoolConstant.True;
                return x;
            }

            if (_reader.Peek() is False)
            {
                Match<False>();
                x = BoolConstant.False;
                return x;
            }

            if (_reader.Peek() is Identifier)
            {
                var token = Match<Identifier>();
                x = new IdentifierNode(token);
                return x;
            }

            throw new Exception("syntax error");
        }
    }
}
