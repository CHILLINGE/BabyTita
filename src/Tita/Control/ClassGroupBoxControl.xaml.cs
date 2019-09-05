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
    public class ClassChangeGroupEventArgs : EventArgs
    {
        public ClassGroup rootGroup { get; set; }
        public int add_delete { get; set; }
    }

    /// <summary>
    /// ClassGroupBoxControl.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class ClassGroupBoxControl : UserControl
    {
        public event EventHandler<EditEventArgs> EditGroupName;
        public event EventHandler<ClassChangeGroupEventArgs> ChangeGroup;
        public event EventHandler<ClassChangeMemberEventArgs> ChangeMember;
        public event EventHandler ElementAdd;

        public ClassGroup root { get; }

        public ClassGroupBoxControl()
        {
            root = new ClassGroup();
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
                GControl.ClassGroupRemove += Groupdelete;
                GControl.ChangeMember += ADChangeMember;
                groupbox.Children.Add(GControl);
            }
        }

        private void EditGroupNameSender(Object sender, EditEventArgs argevent)
        {
            EditGroupName?.Invoke(this, argevent);
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
            ClassChangeGroupEventArgs changeargs = new ClassChangeGroupEventArgs();
            changeargs.rootGroup = new ClassGroup();
            changeargs.add_delete = 1;
            ChangeGroup?.Invoke(this, changeargs);  //info가 추가 되었을 때 추가 : 1
            var GC = new ClassGroupControl(changeargs.rootGroup);
            GC.ClassGroupRemove += Groupdelete;
            GC.ChangeMember += ADChangeMember;
            groupbox.Children.Add(GC); //상위클래스에서 실제그룹 추가해줌
        }

        private void Groupdelete(Object sender, ClassGroupRemoveArgs group)
        {
            ClassChangeGroupEventArgs changeargs = new ClassChangeGroupEventArgs();
            changeargs.rootGroup = group.rootGroup;
            changeargs.add_delete = 0;
            ChangeGroup?.Invoke(this, changeargs);
            groupbox.Children.Remove(sender as ClassGroupControl);  //상위클래스에서 실제그룹 삭제
        }

        /// <summary>
        /// 멤버 추가 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mem"></param>
        private void ADChangeMember(Object sender, ClassChangeMemberEventArgs mem)
        {
            ChangeMember?.Invoke(this, mem);
        }

    }
}
