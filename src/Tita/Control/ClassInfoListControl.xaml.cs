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
    /// ClassListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassInfoListControl : UserControl
    {

        public ClassInfoList ClassDatalist { get; set; }

        public void Update()
        {

            //ClassInfoControl child = new ClassInfoControl();
            //child.Info = ClassDatalist[i];
            //child.VerticalAlignment = VerticalAlignment.Top;
            //child.HorizontalAlignment = HorizontalAlignment.Stretch;
            //child.Margin = new Thickness(5);

            //MainScroll.Children.Add(child);

        }
   
    }
}
