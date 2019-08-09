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
    /// PageHostControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageHostControl : UserControl
    {
        public Dictionary<string, INavigable> Pages { get; private set; }
        public string CurrentEndpoint { get; private set; }

        public PageHostControl()
        {
            InitializeComponent();
            CurrentEndpoint = "";
            Pages = new Dictionary<string, INavigable>();

        }


        public void RegisterPage(string endpoint, INavigable page)
        {
            if (!(page is FrameworkElement))
            {
                throw new Exception("Page is not a valid WPF Control.");
            }
            page.OnNavigate += NavigateCallback;
            ((FrameworkElement)page).Visibility = Visibility.Collapsed;
            
            Pages[endpoint] = page;
            mainHost.Children.Add(page as FrameworkElement);
        }

        public bool ChangePage(string endpoint, object data = null)
        {
            if (Pages.ContainsKey(endpoint))
            {
                FrameworkElement page = Pages[endpoint] as FrameworkElement;

                if (CurrentEndpoint != "")
                {
                    ((FrameworkElement)Pages[CurrentEndpoint]).Visibility = Visibility.Collapsed;
                }
                Pages[endpoint].Navigated(CurrentEndpoint, data);
                page.Visibility = Visibility.Visible;
                CurrentEndpoint = endpoint;
                

                return true;
            }
            return false;
        }

        private void NavigateCallback(object sender, NavigateEventArgs e)
        {
            ChangePage(e.TargetEndpoint, e.Data);

        }
    }
}
