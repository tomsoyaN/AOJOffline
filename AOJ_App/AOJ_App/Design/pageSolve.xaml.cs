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
using AOJ_App.Compile;
using AOJ_App.Editor;

namespace AOJ_App.Design
{
    /// <summary>
    /// Page1.xaml の相互作用ロジック
    /// </summary>
    public partial class Page1 : Page
    {
        private codeeditor peditor;
        private debugger pdebugger;
        public Page1()
        {
            InitializeComponent();
            peditor = new codeeditor(editor);//editor@tom
            pdebugger = new debugger();//コンパイラ部のやつ@tom
            
        }

        private async void Btn_Submit_ClickAsync(object sender, RoutedEventArgs e)//提出ボタン@tom
        {
            var result = await global.net.Submmission();
        }

        private void Btn_Debug_Click(object sender, RoutedEventArgs e)//コンパイラボタン@tom
        {
            pdebugger.Execute(editor.Text);
        }
    }
}
