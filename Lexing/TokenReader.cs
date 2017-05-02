using System.Collections.Generic;
using Lexing.Tokens;

namespace Lexing
{
    public class TokenReader
    {
        private int _pos;
        private readonly List<Token> _tokens;

        public bool EndOfStream => _pos >= _tokens.Count;

        public TokenReader(List<Token> tokens)
        {
            _tokens = tokens;
        }

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
