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

        /// <summary>
        /// 새로운 페이지를 등록한다. 페이지는 INavigable을 구현하는 WPF 컨트롤이어야 한다.
        /// </summary>
        /// <param name="endpoint">페이지가 가질 endpoint</param>
        /// <param name="page">대상 페이지</param>
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


        /// <summary>
        /// 해당 endpoint의 페이지를 표시한다.
        /// </summary>
        /// <param name="endpoint">페이지의 endpoint</param>
        /// <param name="data">페이지에 전달할 데이터</param>
        /// <returns></returns>
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
