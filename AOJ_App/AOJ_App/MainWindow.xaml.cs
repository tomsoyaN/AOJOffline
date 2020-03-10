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
        public MainWindow()
        {
            InitializeComponent();
            var Editor = new codeeditor(editor);
        }

        private void Compile_Click(object sender, RoutedEventArgs e)
        {
            //コンパイラ起動
            //二つ目の引数はコンパイルしたいcppファイルの保存場所およびファイル名
            //a.exeはAOJOffline\AOJ_App\AOJ_App\bin\Debugに保存される模様
            System.Diagnostics.Process.Start("g++", @"C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\test.cpp");
            //生成された実行ファイルを実行
            //二つ目の引数は実行したいexeファイルの保存場所およびファイル名
            //System.Diagnostics.Process.Start("a.exe", @"C:\C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\a.exe");
        }
    }
}
