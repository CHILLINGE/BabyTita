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
    /// ClassGroupBoxControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassGroupBoxControl : UserControl
    {
        public event EventHandler<AddEventArgs> EditGroupName;
        public event EventHandler ElementAdd;

        public ClassGroup root { get; }

        public ClassGroupBoxControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 그룹들을 담는 그룹박스
        /// </summary>
        /// <param name="group"></param>
        public ClassGroupBoxControl(ClassGroup group) : this()
        {
            root = group;
            Update(root);
        }

        public void Update(ClassGroup group)
        {

            foreach (ClassGroup g in group.Children)
            {
                ClassGroupControl GControl = new ClassGroupControl(g);
                GControl.EditGroupName += EditGroupNameSender;
                groupbox.Children.Add(GControl);
            }
        }

        public void GroupControlAdd(ClassGroup group)
        {
            root.AddGroup(group);
            //위로 추가 됬음을 알림
            ClassGroupControl groupControl = new ClassGroupControl(group);
            groupbox.Children.Add(groupControl);
        }

        public void GroupControlDelete()
        {
            //위로 삭제 됬음을 알림
            //groupbox.Children.Remove();
        }

        /// <summary>
        ///새로운 그룹 추가 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ElementAdd != null)
            {
                ElementAdd(this, new EventArgs());
            }
           
        }

        private void EditGroupNameSender(Object sender, AddEventArgs argevent)
        {
            EditGroupName?.Invoke(this, argevent);
        }

    }
}
