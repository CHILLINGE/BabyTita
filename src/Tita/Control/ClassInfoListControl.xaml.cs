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

        //public event EventHandler MouseHoverEvent;
        //private ClassInfoPlus data;
        //public  void DoMouseHover()
        //{
        //    if (MouseHoverEvent != null)
        //        this.data = ;
        //        MouseHoverEvent(this, new EventArgs(this.data));
        //}

        public ClassInfoList ClassDatalist { get; set; }

        public void UpDate()
        {
            foreach (KeyValuePair<string, List<ClassInfo>> item in ClassDatalist.Groups)
            {
                ClassInfoGroupControl child = new ClassInfoGroupControl();


                child.GroupName = item.Key;
                child.ClassDatalist = ClassDatalist.Groups[item.Key];
                child.Update();

                child.VerticalAlignment = VerticalAlignment.Top;
                child.HorizontalAlignment = HorizontalAlignment.Stretch;
                child.MaxHeight = 500;
                child.Margin = new Thickness(5);

                MainScroll.Children.Add(child);
            }
        }
        public ClassInfoListControl()
        {
            InitializeComponent();
        }



    }
}
