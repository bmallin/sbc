using Lexing.Tokens;

namespace Parsing.AstNodes
{
    public class BoolConstant : Constant
    {
        public static BoolConstant True = new BoolConstant("true");
        public static BoolConstant False = new BoolConstant("false");

        private BoolConstant(string value) 
            : base(value)
        {
        }
    }
}
