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

namespace Tita
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainHost.RegisterPage("main", new MainPage());
            mainHost.RegisterPage("groupbuild", new GroupBuildPage());

            mainHost.ChangePage("main");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Scaffold win = new Scaffold();
            DropDownTest win = new DropDownTest();

            win.Show();
        }

        private void smalljb_Click(object sender, RoutedEventArgs e)
        {
            smalljTest s = new smalljTest();
            s.Show();
        }

        private void EZYOONb_Click(object sender, RoutedEventArgs e)
        {
            EZYOONTest a = new EZYOONTest();
            a.Show();
        }
        private void Scaffold_Click(object sender, RoutedEventArgs e)
        {
            Scaffold ss = new Scaffold();
            ss.Show();
        }

        private void Testb_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
