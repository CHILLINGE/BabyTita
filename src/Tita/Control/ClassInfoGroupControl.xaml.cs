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
    /// ClassInfoGroupControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassInfoGroupControl : UserControl
    {

        public List<ClassInfo> ClassDatalist { get; set; }
        public string GroupName { get; set; }
        public ClassInfoControl child;


        public delegate void MyEvent(object sender, SelectSubjectEventArgs info);
        public event MyEvent SelectSubject;

        public void Update()
        {
            GroupNameBox.Header = GroupName;
            for (int i = 0; i < ClassDatalist.Count; i++)
            {
                child = new ClassInfoControl();
                child.Info = ClassDatalist[i];
                child.VerticalAlignment = VerticalAlignment.Top;
                child.HorizontalAlignment = HorizontalAlignment.Stretch;
                child.Margin = new Thickness(5);
                child.MouseEnter += Child_MouseEnter;
                child.MouseLeave += Child_MouseLeave;

                MainScroll.Children.Add(child);
            }

        }

        private void Child_MouseLeave(object sender, MouseEventArgs e)
        {
            ClassInfoControl control = (ClassInfoControl)sender;
            SelectSubjectEventArgs args = new SelectSubjectEventArgs();
            args.Info = control.Info;
            args.IsMouseEnter = false;

            if (SelectSubject != null)
            {
                SelectSubject(this, args);
            }
        }

        private void Child_MouseEnter(object sender, MouseEventArgs e)
        {
            ClassInfoControl control = (ClassInfoControl)sender;
            SelectSubjectEventArgs args = new SelectSubjectEventArgs();
            args.Info = control.Info;
            args.IsMouseEnter = true;

            if (SelectSubject != null)
            {
                SelectSubject(this, args);
            }
        }

        public ClassInfoGroupControl()
        {
            InitializeComponent();
        }

    }

    public class SelectSubjectEventArgs : EventArgs
    {
        public ClassInfo Info { get; set; }
        public Boolean IsMouseEnter { get; set; }
    }
    
}
