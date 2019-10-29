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
    /// GroupBuildPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GroupBuildPage : UserControl, INavigable
    {
        public ClassGroup root { get; private set; }


        public GroupBuildPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataFile file = new DataFile("subjects.xml");
            classList.ClassDatalist = file.LoadClassInfo();

            classList.UpDate();
            classList.SelectSubject += ClassList_SelectSubject;

            root = new ClassGroup();

            //그룹 추가삭제 이벤트
            Gbox.ChangeGroup += Gbox_ChangeGroup;
            //그룹 이름 수정 이벤트
            Gbox.EditGroupName += Gbox_EditGroupName;
            //그룹 멤버 추가삭제 이벤트
            Gbox.ChangeMember += Gbox_ChangeMember;

        }
        private void ClassList_SelectSubject(object sender, SelectSubjectEventArgs info)
        {
            ClassInfoListControl control = (ClassInfoListControl)sender;
            if (info.IsMouseEnter)
            {
                ClassTimePreview.ClassData.Add(info.Info);
                ClassTimePreview.UpDate();
            }
            else
            {
                ClassTimePreview.Remove();
            }
        }

        public event EventHandler<NavigateEventArgs> OnNavigate;

        public void Navigated(string fromEndpoint, object data)
        {
            
        }

        private void BackPage_Click(object sender, RoutedEventArgs e) //mainpage로 이동
        {
            OnNavigate(this, new NavigateEventArgs("main"));
        }

        private void NextPage_Click(object sender, RoutedEventArgs e) //Resultpage로 이동
        {
            OnNavigate(this, new NavigateEventArgs("Result"));
        }

        //그룸의 이름을 수정할 시
        private void Gbox_EditGroupName(Object sender, EditEventArgs argevent)
        {
            //root
        }

        //그룹이 추가되거나 삭제될 시
        private void Gbox_ChangeGroup(Object sender, ClassChangeGroupEventArgs change) 
        {
            if (change.add_delete == 1)
            {
                root.Children.Add(change.rootGroup);
            }
            else
            {
                root.Children.Remove(change.rootGroup);
            }
        }

        //그룹안에 과목이 추가되거나 삭제될 시
        private void Gbox_ChangeMember(Object sender, ClassChangeMemberEventArgs change)
        {
            if (change.add_delete == 1)
            {
                //add
                change.rootGroup.Children.Add((IGroupable)change.changeInfo);
            }
            else
            {
                //delete
                change.rootGroup.Children.Remove((IGroupable)change.changeInfo);
            }
        }
    }
}
