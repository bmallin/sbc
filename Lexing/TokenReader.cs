using System.Collections.Generic;
using Lexing.Tokens;

namespace Lexing
{
    public class TokenReader
    {
        private readonly List<Token> _tokens;
        private int _pos;

        public TokenReader(List<Token> tokens)
        {
            _tokens = tokens;
        }

        public bool EndOfStream => _pos >= _tokens.Count;

        public Token Peek()
        {
            return EndOfStream ? null : _tokens[_pos];
        }

        public Token Read()
        {
            var token = Peek();

            _pos++;

            return token;
        }

        public void Reset()
        {
            _pos = 0;
        }
    }
}