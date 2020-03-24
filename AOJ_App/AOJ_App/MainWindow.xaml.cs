using System;
using System.Collections.Generic;
using System.IO;
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

        private async void Compile_Click(object sender, RoutedEventArgs e)
        {

            //エディタの文をcppファイルとして保存
            //文字コードの指定
            Encoding enc = Encoding.GetEncoding("utf-8");
            //保存場所の指定,0000はファイル名
            StreamWriter writer = new StreamWriter(@"C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\0000.cpp", false, enc);
            writer.Write(editor.Text);
            writer.Close();

            //cppファイルが生成されるのを待つ(mms)
            await Task.Delay(3000);

            //コンパイラ起動
            //二つ目の引数はコンパイルしたいcppファイルの保存場所およびファイル名
            //a.exeはAOJOffline\AOJ_App\AOJ_App\bin\Debugに保存される模様
            System.Diagnostics.Process.Start("g++", @"C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\0000.cpp");

            //exeファイルが生成されるのを待つ
            await Task.Delay(3000);

            //生成された実行ファイルを実行
            //二つ目の引数は実行したいexeファイルの保存場所およびファイル名
            System.Diagnostics.Process.Start("a.exe", @"C:\C:\Users\Owner\source\repos\AOJOffline\AOJ_App\AOJ_App\bin\Debug\a.exe");
        }

    }
}
