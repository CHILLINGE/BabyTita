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
    /// EZYOONTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EZYOONTest : Window
    {
        public EZYOONTest()
        {
            InitializeComponent();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classList.SelectSubject += ClassList_SelectSubject;

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
                ClassTimePreview.ClassData.Clear();
                ClassTimePreview.UpDate();
            }
        }

        private void MainlistUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Mainlist.ClassDatalist = TestData.GetClassInfos(1);
            //Mainlist.ClassDatalist.RemoveAt(0);
            //Mainlist.Update();

            TestFunctions.xmlparsetest();
        }

        private void ElementAdded(object sender, EventArgs e)
        {
            MessageBox.Show("Event!");
        }

        private void ClassListupdate_Click(object sender, RoutedEventArgs e)
        {
            DataFile file = new DataFile("subjects.xml");
            classList.ClassDatalist = file.LoadClassInfo();

            classList.UpDate();
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            ResultSchedule.ClassData = TestData.GetClassInfos();
            ResultSchedule.UpDate();
        }
    }
}
