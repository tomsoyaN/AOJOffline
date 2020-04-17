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

namespace AOJ_App.Design
{
    /// <summary>
    /// Page1.xaml の相互作用ロジック
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            var peditor = new codeeditor(editor);
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Debug_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
