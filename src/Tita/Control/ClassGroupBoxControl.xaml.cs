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
        public event EventHandler<EditEventArgs> EditGroupName;
        public event EventHandler<ClassChangeGroupEventArgs> ChangeGroup;
        public event EventHandler<ClassChangeMemberEventArgs> ChangeMember;
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
                GControl.ChangeGroup += ADChangeGroup;
                GControl.ChangeMember += ADChangeMember;
                groupbox.Children.Add(GControl);
            }
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

        private void EditGroupNameSender(Object sender, EditEventArgs argevent)
        {
            EditGroupName?.Invoke(this, argevent);
        }

        /// <summary>
        ///그룹 추가 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="group"></param>
        public void ADChangeGroup(Object sender, ClassChangeGroupEventArgs group)
        {
            if (group.add_delete == 0) GroupControlDelete(sender, group);
            else GroupControlAdd(sender, group);
        }

        public void GroupControlAdd(Object sender, ClassChangeGroupEventArgs group)
        {
            root.AddGroup(group.rootGroup);
            //위로 추가 됬음을 알림
            ChangeGroup?.Invoke(this, group);
            ClassGroupControl groupControl = new ClassGroupControl(group.rootGroup);
            groupbox.Children.Add(groupControl);
        }

        public void GroupControlDelete(Object sender, ClassChangeGroupEventArgs group)
        {
            //위로 삭제 됬음을 알림
            ChangeGroup?.Invoke(this, group);
            groupbox.Children.Remove(sender as ClassGroupControl);
        }

        public void GControlAdd(ClassGroup group)
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
        /// 멤버 추가 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mem"></param>
        public void ADChangeMember(Object sender, ClassChangeMemberEventArgs mem)
        {
            ChangeMember?.Invoke(this, mem);
        }

    }
}
