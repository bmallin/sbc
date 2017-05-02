using System;
using System.IO;
using Lexing;
using Parsing;

namespace sbc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = "samples/random.sb";

            using (var file = new StreamReader(filePath))
            {
                var lexer = new Lexer(file);
                var tokens = lexer.GetTokens();

                foreach (var token in tokens)
                {
                    Console.WriteLine(token);
                }

                var reader = new TokenReader(tokens);
                var parser = new Parser(reader);

                parser.BuildAst();
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
