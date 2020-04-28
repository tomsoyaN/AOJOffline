using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Document;

namespace AOJ_App.Editor
{
    class Block2 : IDisposable
    {
        static public readonly int ACTIVE = 1;
        static public readonly int DEACTIVE = 0;
        public List<Block2> blocks { get; set; }
        public Block2 parent { get; set; }
        private TextAnchor start;
        public TextAnchor end;
        public int depth;
        private int m_state;

        public int startpos
        {
            get{ return this.start.Offset; }
        }
        public int endpos
        {
            get { return this.end.Offset; }
        }

        public int state
        {
            get { return this.m_state;}
            set { this.m_state = state; }
        }
        public Block2(Block2 par, TextAnchor s, TextAnchor e, int d)
        {
            blocks = new List<Block2>();
            start = s;
            end = e;
            parent = par;
            depth = d;
            m_state = ACTIVE;
        }

        public void TurnDEACTIVE(string target)
        {
            if(target == "{")
            {
                this.start = null;
            } else
            {
                this.end = null;
            }
            this.state = DEACTIVE;
        }
        public void Dispose()
        {   
            if(this.parent != null) this.parent.blocks.Remove(this);
        }
    }
}
