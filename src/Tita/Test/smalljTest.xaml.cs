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
using System.Windows.Shapes;

namespace Tita
{
    /// <summary>
    /// smalljTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class smalljTest : Window
    {
        public smalljTest()
        {
            InitializeComponent();
        }

        private Point startPoint;

        private void Small_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            DataFile file = new DataFile("subjects.xml");
            ClassInfoList lst = file.LoadClassInfo();
            Console.WriteLine(lst.Groups);
            ClassGroup gone = new ClassGroup();
            ClassGroup gtwo = new ClassGroup();
            ClassGroup group = new ClassGroup();

            foreach(ClassInfo i in lst.Groups["컴퓨터정보공학부"])
            {
                gone.AddGroup(new ClassInfoPlus(i));
            }
            foreach (ClassInfo i in lst.Groups["자교"])
            {
                gtwo.AddGroup(new ClassInfoPlus(i));
            }

            group.AddGroup(gone);
            group.AddGroup(gtwo);

            ClassGroupBoxControl gbox = new ClassGroupBoxControl(group);
            main.Children.Add(gbox);
            */


            ClassInfo info = new ClassInfo("객체지향패러다임", 0, new ClassTime(new ClassTimeItem(DayOfWeek.Monday, 1, 3)), "오재원", 3);
            DragSubject.Children.Add(new ClassInfoControl(info));
        }

        private void List_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);           
        }

        private void List_MouseMove(object sender, MouseEventArgs e)
        {
            Point nowPoint = e.GetPosition(null);
            Vector coor = startPoint - nowPoint;

            if(e.LeftButton == MouseButtonState.Pressed && 
                Math.Abs(coor.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(coor.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                StackPanel list = sender as StackPanel;
                ClassInfoControl dragItem = FindAnchestor<ClassInfoControl>((DependencyObject)e.OriginalSource);
                if (dragItem == null) return;

                ClassInfo info = dragItem.Info;

                DataObject dragData = new DataObject();
                dragData.SetData("SubjectInfo", info);
                dragData.SetData("Object", this);
                DragDrop.DoDragDrop(this, dragData, DragDropEffects.Move | DragDropEffects.Copy);
            }

        }

        private static T FindAnchestor<T> (DependencyObject current)
            where T : DependencyObject
        {
            while(current != null)
            {
                if(current is T)
                {
                    return current as T;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        private void MouseCursurFeedback()
        {

        }
        
        private void Data_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent("SubjectInfo"))
            {
                ClassInfo dragItem = e.Data.GetData("SubjectInfo") as ClassInfo;
                StackPanel Dropsubject = sender as StackPanel;
                ClassInfoControl item = new ClassInfoControl(dragItem);
                Dropsubject.Children.Add(item);
            }
        }

        private void Data_DragEnter(object sender, DragEventArgs e)
        {
            if(!e.Data.GetDataPresent("SubjectInfo") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
    }
}
