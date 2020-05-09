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
    /// Interaction logic for ChooseProblem.xaml
    /// </summary>
    public partial class ChooseProblem : UserControl
    {
        public ChooseProblem()
        {
            InitializeComponent();
        }
        /*** よくわからないので修正お願いします。
        private async void Btn_Choose_ClickAsync(object sender, RoutedEventArgs e) //問題表示@kurikinton
        {
            
            var url = "/Design/pageSolve.xaml";
            var bb = new BBCodeBlock();
            bb.LinkNavigator.Navigate(new Uri(url, UriKind.Relative), this);

        }
        ***/
    }
}
