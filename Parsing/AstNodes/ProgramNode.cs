using System.Collections.Generic;

namespace Parsing.AstNodes
{
    public class ProgramNode : AstNode
    {
        public ProgramNode(List<LineNode> lines)
        {
            Lines = lines;
        }

        public List<LineNode> Lines { get; }
    }
}