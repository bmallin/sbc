using System;
using System.IO;
using Lexing;

namespace sbc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = "samples/random.sb";

            using (var file = new StreamReader(File.OpenRead(filePath)))
            {
                var lexer = new Lexer(file);
                var tokens = lexer.GetTokens();

                foreach (var token in tokens)
                {
                    Console.WriteLine(token);
                }
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
