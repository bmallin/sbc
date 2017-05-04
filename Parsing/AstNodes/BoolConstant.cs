namespace Parsing.AstNodes
{
    public class BoolConstant : Constant
    {
        public static BoolConstant False = new BoolConstant("false");
        public static BoolConstant True = new BoolConstant("true");

        private BoolConstant(string value)
            : base(value)
        {
        }
    }
}