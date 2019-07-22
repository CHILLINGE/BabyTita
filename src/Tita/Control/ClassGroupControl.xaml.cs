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
    public class AddEventArgs : EventArgs
    {
        public string newname { get; set; }
    }


    /// <summary>
    /// ClassGroupControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassGroupControl : UserControl
    {
        public delegate void mydel(object sender, AddEventArgs e);
        public event mydel EditGroupName;

        public ClassGroupControl()
        {
            InitializeComponent();
            editbutton.Visibility = Visibility.Hidden;
            editname.Visibility = Visibility.Hidden;
        }

        public ClassGroup Group { get; set; }

        /// <summary>
        /// 새로운 그룹 추가
        /// </summary>
        /// <param name="group"></param>
        public ClassGroupControl(ClassGroup group) : this()
        {
            this.Group = group;
            BasketUpdate();
        }

        /// <summary>
        /// 그룹에 새롭게 과목을 추가,삭제할 때마다 부르는 클래스
        /// </summary>
        /// <param name="group"></param>
        public void BasketUpdate()
        {
            foreach (IGroupable item in Group.Children)
            {
                if (Group.IsitGroup(item)) { }
                else
                {
                    ClassInfoControl groupitem = new ClassInfoControl((ClassInfoPlus)item);
                    basketstack.Children.Add(groupitem);
                }
            }
        }

        private void DragSubject_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(nameof(ClassInfo)))
            {
                e.Effects = DragDropEffects.Move;
            }
        }

        private void Data_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled == false)
            {
                StackPanel panel = sender as StackPanel;
                ClassInfo curinfo = e.Data.GetData(nameof(ClassInfo)) as ClassInfo;
                ClassInfoPlus infoplus = new ClassInfoPlus(curinfo);
                if (panel != null && curinfo != null)
                {

                    ClassInfoControl curcontrol = new ClassInfoControl(infoplus);
                    curcontrol.AllowDrop = false;
                    panel.Children.Add(curcontrol);
                    e.Effects = DragDropEffects.Move;
                }

            }
        }



        private void penClick(object sender, RoutedEventArgs e)
        {
            groupname.Visibility = Visibility.Hidden;
            penb.Visibility = Visibility.Hidden;
            editbutton.Visibility = Visibility.Visible;
            editname.Visibility = Visibility.Visible;

            String name = groupname.Text;
            editname.Text = name;
        }

        private void editClick(object sender, RoutedEventArgs e)
        {
            AddEventArgs argevent = new AddEventArgs();
            argevent.newname = editname.Text;

            if(EditGroupName != null)
            {
                EditGroupName(this, argevent);
            }
            //참고 EditGroupName?.Invoke(this, argevent); (?.은 앞의 변수가 null이면 무시)

            groupname.Text = argevent.newname;

            groupname.Visibility = Visibility.Visible;
            penb.Visibility = Visibility.Visible;
            editbutton.Visibility = Visibility.Hidden;
            editname.Visibility = Visibility.Hidden;

            //위에 바꼈음을 알려주는 이벤트 코드 추가
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
