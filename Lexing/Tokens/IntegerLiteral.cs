using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexing.Tokens
{
    public class IntegerLiteral : NumberLiteral
    {
        public IntegerLiteral(string value)
            : base(value)
        {
        }
    }
}
