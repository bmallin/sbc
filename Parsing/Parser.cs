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

            Match<LineTerminator>();

            return new LineNode(lineNumber, statement);
        }

        private StatementNode ParseStatement()
        {
            var statementIdent = Match<Identifier>();

            switch (statementIdent.Value.ToLower())
            {
                case "let":
                    return ParseLetStatement();
                default:
                    throw new Exception($"Unexpected statement: {statementIdent.Value}");
            }
        }

        private LetStatementNode ParseLetStatement()
        {
            var lhs = Match<Identifier>();
            Match<Assign>();

            var rhs = ParseExpression();

            return new LetStatementNode(lhs, rhs);
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
                Match(typeof(Equal), typeof(NotEqual));
                lhs = new 
            }
        }

        private ExpressionNode ParseRel()
        {
            return ParseMathExpr();
        }

        private ExpressionNode ParseMathExpr()
        {
            return ParseTerm();
        }

        private ExpressionNode ParseTerm()
        {
            ParseUnary();

            while (_reader.Peek() is Slash || _reader.Peek() is Asterisk)
            {
                Match(typeof(Slash), typeof(Asterisk));

            }
        }

        private ExpressionNode ParseUnary()
        {
            switch (_reader.Peek())
            {
                case Dash t:
                    Match<Dash>();
                    break;
                case Bang t:
                    Match<Bang>();
                    break;
                default:
                    ParseFactor();
                    break;

            }
        }

        private ExpressionNode ParseFactor()
        {
            switch (_reader.Peek())
            {
                case LeftParen t:
                    Match<LeftParen>();
                    return ParseExpression();
                    Match<RightParen>();
                    break;
                case IntegerLiteral t:
                    Match<IntegerLiteral>();
                    break;
                case FloatLiteral t:
                    Match<FloatLiteral>();
                    break;
                case True t:
                    Match<True>();
                    break;
                case False t:
                    Match<False>();
                    break;
                case Identifier t:
                    Match<Identifier>();
                    // lookup in symtable
                    break;
                default:
                    throw new Exception("Error parsing expression.");
            }            
        }
    }
}
