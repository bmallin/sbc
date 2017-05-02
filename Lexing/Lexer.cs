using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lexing.Tokens;

namespace Lexing
{
    public class Lexer
    {
        private static readonly HashSet<char> Symbols = new HashSet<char>
        {
            '+',
            '-',
            '*',
            '/',
            '%',
            '^',
            '"',
            '(',
            ')',
            ',',
            '<',
            '>',
            '=',
            '!'
        };

        private readonly StreamReader _reader;
        private readonly StringBuilder _tokenBuffer;

        public Lexer(StreamReader reader)
        {
            _reader = reader;
            _tokenBuffer = new StringBuilder();
        }

        public List<Token> GetTokens()
        {
            var tokens = new List<Token>();

            while (!_reader.EndOfStream)
            {
                if (char.IsDigit(Peek()))
                {
                    tokens.Add(ReadNumberLiteral());
                }
                else if (Peek() == '"')
                {
                    tokens.Add(ReadStringLiteral());
                }
                else if (char.IsLetter(Peek()))
                {
                    tokens.Add(ReadIdentifier());
                }
                else if (IsSymbol(Peek()))
                {
                    tokens.Add(ReadSymbol());
                }
                else if (Peek() == '\n')
                {
                    Consume();
                    tokens.Add(CreateToken<LineTerminator>());
                }
                else if (Peek() == '#')
                {
                    Skip(c => c != '\n');
                    Skip();
                    tokens.RemoveAt(tokens.Count - 1);
                }
                else if (char.IsWhiteSpace(Peek()))
                {
                    Skip();
                }
                else
                {
                    throw new Exception($"Unexpected character encountered: {Peek()}");
                }
            }

            return tokens;
        }

        private char Peek()
        {
            return (char) _reader.Peek();
        }

        private void Consume()
        {
            _tokenBuffer.Append((char) _reader.Read());
        }

        private void Skip()
        {
            _reader.Read();
        }

        private void Skip(Func<char, bool> predicate)
        {
            while (predicate(Peek()))
                _reader.Read();
        }

        private void Gobble(Func<char, bool> predicate)
        {
            while (predicate(Peek()))
                Consume();
        }

        private T CreateToken<T>() where T : Token
        {
            var value = _tokenBuffer.ToString();

            _tokenBuffer.Clear();

            return (T) Activator.CreateInstance(typeof(T), value);
        }

        private NumberLiteral ReadNumberLiteral()
        {
            var isFloat = false;

            Gobble(char.IsDigit);
            if (Peek() == '.')
            {
                isFloat = true;
                Gobble(char.IsDigit);
            }

            if (isFloat)
                return CreateToken<FloatLiteral>();

            return CreateToken<IntegerLiteral>();
        }

        private StringLiteral ReadStringLiteral()
        {
            if (Peek() == '"')
            {
                Consume();
                Gobble(c => c != '"');
            }

            Consume();

            return CreateToken<StringLiteral>();
        }

        private Identifier ReadIdentifier()
        {
            if (char.IsLetter(Peek()))
                Consume();

            Gobble(c => char.IsLetter(c) || char.IsDigit(c) || c == '_');

            return CreateToken<Identifier>();
        }

        private Symbol ReadSymbol()
        {
            switch (Peek())
            {
                case '+':
                    Consume();
                    return CreateToken<Plus>();
                case '-':
                    Consume();
                    return CreateToken<Dash>();
                case '*':
                    Consume();
                    return CreateToken<Asterisk>();
                case '/':
                    Consume();
                    return CreateToken<Slash>();
                case '%':
                    Consume();
                    return CreateToken<Percent>();
                case '^':
                    Consume();
                    return CreateToken<Caret>();
                case '(':
                    Consume();
                    return CreateToken<LeftParen>();
                case ')':
                    Consume();
                    return CreateToken<RightParen>();
                case ',':
                    Consume();
                    return CreateToken<Comma>();
                case '!':
                    Consume();
                    if (Peek() != '=')
                        return CreateToken<Bang>();

                    Consume();
                    return CreateToken<NotEqual>();

                case '=':
                    Consume();
                    if (Peek() != '=')
                        return CreateToken<Assign>();

                    Consume();
                    return CreateToken<Equal>();

                case '>':
                    Consume();
                    if (Peek() != '=')
                        return CreateToken<GreaterThan>();

                    Consume();
                    return CreateToken<GreaterThanOrEqual>();

                case '<':
                    Consume();
                    if (Peek() != '=')
                        return CreateToken<LessThan>();

                    Consume();
                    return CreateToken<LessThanOrEqual>();
                case '|':
                    Consume();
                    if (Peek() == '|')
                        return CreateToken<Or>();
                    break;
                case '&':
                    Consume();
                    if (Peek() == '&')
                        return CreateToken<And>();
                    break;
                default:
                    throw new Exception($"Unknown symbol: {Peek()}");
            }

            return null;
        }

        private static bool IsSymbol(char c)
        {
            return Symbols.Contains(c);
        }
    }
}