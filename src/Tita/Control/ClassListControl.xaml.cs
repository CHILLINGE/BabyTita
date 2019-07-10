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
    public partial class ClassListControl : UserControl
    {
        private List<ClassInfo> ListBackup;
        public List<ClassInfo> ClassDatalist { get; set; }

        public void Update()
        {
            MainScroll.Children.Clear();
            if (ListBackup == ClassDatalist)
            {
                for (int i = 0; i < ClassDatalist.Count; i++)
                {
                    ClassInfoControl child = new ClassInfoControl();
                    child.Info = ClassDatalist[i];
                    child.VerticalAlignment = VerticalAlignment.Top;
                    child.HorizontalAlignment = HorizontalAlignment.Left;

                    MainScroll.Children.Add(child);
                }
            }
            else
            {
                for (int i = 0; i < ClassDatalist.Count; i++)
                {
                    ClassInfoControl child = new ClassInfoControl();
                    child.Info = ClassDatalist[i];
                    child.VerticalAlignment = VerticalAlignment.Top;
                    child.HorizontalAlignment = HorizontalAlignment.Left;

                    MainScroll.Children.Add(child);
                }
            }
        }


        public ClassListControl()
        {
            InitializeComponent();
            ListBackup = null;


        }

    }
}
