  using System.Collections.Generic;
  using Lexing.Tokens;

namespace Parsing
{
    public class Parser
    {
        private int currentPos;
        private List<Token> _tokens;

        public Token Peek => _tokens[currentPos];

        public Parser()
        {
            _tokens = new List<Token>();
        }

        public void Parse()
        {
            
        }

        private void Next()
        {
            currentPos++;
        }

        private void ParseProgram()
        {
            
        }

        private void ParseLines()
        {
            
        }

        private void ParseLine()
        {
            
        }

        private void ParseStatement()
        {
            
        }

        private void ParseExpression()
        {
            var output = new Queue<Token>();
            var stack = new Stack<Token>();

            while (true)
            {
                if (Peek is NumberLiteral || Peek is StringLiteral)
                {
                    output.Enqueue(Peek);
                }

                if (Peek is Identifier)
                {
                    stack.Push(Peek);
                }

                if (Peek is Comma)
                {
                    while (!(Peek is LeftParen))
                    {
                        output.Enqueue(stack.Pop());
                    }
                }
            }
        }
    }
}
