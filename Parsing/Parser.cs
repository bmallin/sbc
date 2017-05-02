  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Lexing;
  using Lexing.Tokens;

namespace Parsing
{
    public class Parser
    {
        private readonly TokenReader _reader;

        public Parser(TokenReader reader)
        {
            _reader = reader;
        }

        public void BuildAst()
        {
            ParseProgram();
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

        private void ParseProgram()
        {
            while (!_reader.EndOfStream)
            {
                ParseLines();
            }
        }

        private void ParseLines()
        {
            while (_reader.Peek() is IntegerLiteral)
            {
                ParseLine();
            }
        }

        private void ParseLine()
        {
            Match<IntegerLiteral>();
            ParseStatement();
            Match<LineTerminator>();
        }

        private void ParseStatement()
        {
            var statementIdent = Match<Identifier>();

            switch (statementIdent.Value.ToLower())
            {
                case "let":
                    ParseLetStatement();
                    break;
                case "print":
                    ParsePrintStatement();
                    break;
                default:
                    throw new Exception($"Unexpected statement: {statementIdent.Value}");
            }
        }

        private void ParseLetStatement()
        {
            Match<Identifier>();
            Match<Assign>();

            ParseExpression();
        }

        private void ParseExpression()
        {
            ParseJoin();
        }

        private void ParseJoin()
        {
            ParseEquality();
        }

        private void ParseEquality()
        {
            ParseRel();
        }

        private void ParseRel()
        {
            ParseExpr();
        }

        private void ParseExpr()
        {
            ParseTerm();
        }

        private void ParseTerm()
        {
            ParseUnary();

            while (_reader.Peek() is Slash || _reader.Peek() is Asterisk)
            {
                Match(typeof(Slash), typeof(Asterisk));

            }
        }

        private void ParseUnary()
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

        private void ParseFactor()
        {
            switch (_reader.Peek())
            {
                case LeftParen t:
                    Match<LeftParen>();
                    ParseExpression();
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

        private void ParsePrintStatement()
        {
            ParseExpression();

            while (_reader.Peek() is Comma)
            {
                Match<Comma>();
                ParseExpression();
            }

            Match<LineTerminator>();
        }
    }
}
