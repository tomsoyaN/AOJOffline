using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Document;

namespace AOJ_App.Editor
{
    class Block2
    {
        public List<Block2> blocks { get; set; }
        public Block2 parent { get; set; }
        public TextAnchor start;
        public TextAnchor end;
        public int depth;

        public int startpos
        {
            get{ return this.start.Offset; }
        }
        public int endpos
        {
            get { return this.end.Offset; }
        }
        public Block2(Block2 par, TextAnchor s, TextAnchor e, int d)
        {
            blocks = new List<Block2>();
            start = s;
            end = e;
            parent = par;
            depth = d;
        }

    }
}
