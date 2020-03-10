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
    /// ResultPageListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResultPageListControl : UserControl
    {
        public ResultPageListControl()
        {
            InitializeComponent();
        }

       
        public ResultPageListControl(List<ClassInfo> list)
        {
            Update(list);
        }

        public void Update(List<ClassInfo> list)
        {
            DeleteChildren();
            foreach(ClassInfo item in list)
            {
                ClassInfoControl info = new ClassInfoControl(item);
                Front.Children.Add(info);
            }
        }

        public void DeleteChildren()
        {
            Front.Children.Clear();
        }
    }
}
