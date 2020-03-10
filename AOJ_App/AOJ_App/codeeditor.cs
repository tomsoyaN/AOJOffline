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

namespace AOJ_App
{
    class codeeditor
    {
        ICSharpCode.AvalonEdit.TextEditor editor;
        private CompletionWindow completewind;

        public codeeditor(ICSharpCode.AvalonEdit.TextEditor e)
        {
            editor = e;
            editor.TextArea.TextEntered += TextArea_TextEntered;
            editor.TextArea.TextEntering += TextArea_TextEntering;
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
        }

        private async void TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
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
            }
        }

    }
}
