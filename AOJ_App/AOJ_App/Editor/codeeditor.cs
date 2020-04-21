using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;

namespace AOJ_App.Editor
{
    class codeeditor
    {
        ICSharpCode.AvalonEdit.TextEditor editor;
        private CompletionWindow completewind;
        private Block txts;
        private Block curblock;
        private const int nil = Int32.MinValue;
        private int length = 0;
        public codeeditor(ICSharpCode.AvalonEdit.TextEditor e)
        {
            editor = e;
            editor.TextArea.TextEntered += TextArea_TextEntered;
            editor.TextArea.TextEntering += TextArea_TextEntering;
            editor.TextArea.SelectionChanged += TextArea_SelectionChanged;
            txts = new Block(null,nil,nil,nil,nil,0);
            curblock = txts;
        }



        private void insertText(int pos, string tex)
        {
            editor.Select(pos, 0);
            editor.SelectedText = tex;
            editor.SelectionLength = 0;
        }

        private void TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completewind != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    completewind.CompletionList.RequestInsertion(e);
                }
            }
            if(e.Text == "\t") System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        private async void TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            curblock = GetCurBlock(editor.SelectionStart-1);
            txts.UpdatePos(editor.Document.TextLength - length, editor.SelectionStart-1);
            if (e.Text == ".")
            {
                completewind = new CompletionWindow(editor.TextArea);
                IList<ICompletionData> data = completewind.CompletionList.CompletionData;
                data.Add(new CompletionData("test1"));
                completewind.Show();
                completewind.Closed += delegate
                {
                    completewind = null;
                };

            } else if (e.Text == "(")
            {
                insertText(editor.SelectionStart, ")");
            } else if (e.Text == "{")
            {
                
                txts.UpdatePos(3+curblock.depth, editor.SelectionStart-1);
                txts.UpdateLineNum(2,editor.SelectionStart-1);
                curblock.blocks.Add(new Block(curblock, editor.SelectionStart - 1, editor.SelectionStart+2+curblock.depth, GetCurrentLineNum(), GetCurrentLineNum()+2, curblock.depth + 1));
                string tab = "";
                for (int i = 0; i < curblock.depth;++i) tab += '\t';
                insertText(editor.SelectionStart, "\n\n"+tab+"}");
            } else if (e.Text == "\n")
            {
                txts.UpdatePos(GetPrevTabCount(), editor.SelectionStart - 1);
                txts.UpdateLineNum(1,editor.SelectionStart-1);
            } else if (e.Text == "$")
            {
                System.Diagnostics.Debug.WriteLine(editor.SelectionStart);
            } else if(e.Text == "\t")
            {
                System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                txts.UpdatePos(1, editor.SelectionStart - 1);
            }
            length = editor.Document.TextLength;
        }

        private void Document_Changed()
        {

        }
        private int GetCurrentLineNum()
        {
            int pos = 0, line = 1;
            while (pos < editor.SelectionStart)
            {
                if (editor.Text.Length > pos && editor.Text[pos] == '\n') line++;
                pos++;
            }
            return line;
        }
        private void TextArea_SelectionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(editor.SelectionStart);
        }

        private int GetPrevTabCount()
        {
            int pos = editor.SelectionStart - 2, cnt = 0;
            while (editor.Text[pos] != '\n' && pos > 0) pos--;
            while(editor.Text[++pos] == '\t') cnt++;
            return cnt;
        }
        private Block GetCurBlock(int pos)
        {
            bool flag = true ;
            Block cur = new Block(null, nil, nil, nil, nil, 0);
            cur = txts;
            while (true)
            {
                flag = true;
                foreach (Block o in cur.blocks)
                {             
                    if(o.startpos <= pos && o.endpos >= pos)
                    {
                            flag = false;
                            cur = o;
                            break;          
                    }
                }
                if (flag) return cur;
            }
        }
    }
}
