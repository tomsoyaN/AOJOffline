using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;

namespace AOJ_App
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompletionWindow completewind;
        public MainWindow()
        {
            InitializeComponent();
            editor.TextArea.TextEntered += TextArea_TextEntered;
            editor.TextArea.TextEntering += TextArea_TextEntering;
            
            
        }

        private void TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if(e.Text.Length > 0 && completewind != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                   completewind.CompletionList.RequestInsertion(e);
                }
            }
        }

        private async void TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if(e.Text == ".")
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
