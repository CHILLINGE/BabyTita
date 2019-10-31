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
using Tita.Algorithm;

namespace Tita
{
    /// <summary>
    /// ResultPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResultPage : UserControl, INavigable
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        public event EventHandler<NavigateEventArgs> OnNavigate;

        public void Navigated(string fromEndpoint, object data)
        {
            var algo = new BruteForceClassSelector();
            var result = algo.Calculate((ClassGroup)data);
            
        }

        private void BackPage_Click(object sender, RoutedEventArgs e) //mainpage로 이동
        {
            OnNavigate(this, new NavigateEventArgs("groupbuild"));
        }
    }
}
