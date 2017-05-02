using System.Collections.Generic;

namespace Parsing.AstNodes
{
    public class ProgramNode : AstNode
    {
        public List<LineNode> Lines { get; }

        public ProgramNode(List<LineNode> lines)
        {
            Lines = lines;
        }
    }
}
