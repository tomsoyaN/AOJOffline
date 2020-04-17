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
using FirstFloor.ModernUI.Windows.Controls;

namespace AOJ_App.Design
{
    /// <summary>
    /// pageLogin.xaml の相互作用ロジック
    /// </summary>
    public partial class pageLogin : Page
    {
        public pageLogin()
        {
            InitializeComponent();
            
        }

        private async void Btn_Login_ClickAsync(object sender, RoutedEventArgs e)
        {
            var login = await global.net.Login(txtID.Text,txtPass.Text);
            if (login)
            {
                var url = "/Design/pageSolve.xaml";
                var bb = new BBCodeBlock();
                bb.LinkNavigator.Navigate(new Uri(url, UriKind.Relative), this);
                // You may want to set some property in that page's ViewModel, for example, indicating the selected User ID.
            }

        }
    }
}
