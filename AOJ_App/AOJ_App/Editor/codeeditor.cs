using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;

namespace AOJ_App.Editor
{
    class codeeditor
    {
        ICSharpCode.AvalonEdit.TextEditor editor;
        private CompletionWindow completewind;
        private Block2 txts;
        private Block2 curblock;
        private const int nil = Int32.MinValue;
        private int length = 0;

        public codeeditor(ICSharpCode.AvalonEdit.TextEditor e)
        {
            editor = e;
            editor.TextArea.TextEntered += TextArea_TextEntered;
            editor.TextArea.TextEntering += TextArea_TextEntering;
            editor.TextArea.SelectionChanged += TextArea_SelectionChanged;
            editor.Document.Changed += Document_Changed;
            txts = new Block2(null,null,null,0);
            curblock = txts;
        }

        private void Document_Changed(object sender, DocumentChangeEventArgs e)
        {
            if (e.RemovedText.Text.Contains("}")
            {
                int offset = e.Offset - e.RemovalLength + e.RemovedText.Text.IndexOf("}");
                Block2 block = GetCurBlock(offset,false);
                if(block.state == Block2.DEACTIVE)
                {
                    block.Dispose();
                } 

            }
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
            curblock = GetCurBlock(editor.SelectionStart-1,true);
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
                Block2 test = new Block2(null, editor.Document.CreateAnchor(editor.SelectionStart - 1), editor.Document.CreateAnchor(editor.SelectionStart),curblock.depth+1);
                string tab = "\n\n";
                for (int i = 0; i < curblock.depth;++i) tab += '\t';
                editor.Document.Insert(editor.SelectionStart,tab + "}");
                test.end = editor.Document.CreateAnchor(editor.SelectionStart-1);
                curblock.blocks.Add(test);
            } else if (e.Text == "$")
            {
                System.Diagnostics.Debug.WriteLine(editor.SelectionStart);
            }
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
        private Block2 GetCurBlock(int pos,bool onlyACTIVE)
        {
            bool flag = true ;
            Block2 cur = new Block2(null,null,null,0);
            cur = txts;
            while (true)
            {
                flag = true;
                foreach (Block2 o in cur.blocks)
                {
                    bool isACTIVE = onlyACTIVE == true ? o.state == Block2.ACTIVE : true;
                    if (o.startpos <= pos && o.endpos >= pos && o.state == Block2.ACTIVE) 
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
