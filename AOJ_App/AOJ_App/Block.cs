using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOJ_App
{
    class Block
    {
        public List<Block> blocks { get; set; }
        public Block parent { get; set; }
        public int startpos { get; set; }
        public int endpos { get; set; }
        public int startline { get; set; }
        public int endline { get; set; }
        public int depth { get; set; }
    
        public Block(Block par, int s, int e, int sl, int el, int d)
        {
            blocks = new List<Block>();
            parent = par;
            startpos = s;
            startline = sl;
            endline = el;
            endpos = e;
            depth = d;
        }

        public void UpdatePos(int c,int pos)
        {
            if (parent != null)
            {
                if (pos <= startpos) startpos += c;
                if (pos <= endpos) endpos += c;
            }
            foreach (var b in blocks)
            {
                b.UpdatePos(c, pos);
            }
            
        }
        public void UpdateLineNum(int c,int pos)
        {
            if (parent != null)
            {
                if (pos <= startpos) startline+=c;
                if (pos <= endpos) endline+=c;
            }
            foreach (var b in blocks)
            {
                b.UpdateLineNum(c,pos);
            }

        }
        public void GetLineNum(string text)
        {
            int pos = 0, line = 1;
            while(pos <= endpos)
            {
                if (pos == startpos) startline = line;
                if (text[line] == '\n') line++;
                pos++;
            }
            endline = line;
        }
    }
}
