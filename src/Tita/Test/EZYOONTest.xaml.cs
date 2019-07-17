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
            //Sample.Info = TestData.GetClassInfos()[0];
            //ClassGroup group = new ClassGroup();
            //ClassInfoPlus info = new ClassInfoPlus(Sample.Info);
            //group.AddGroup(info);

            //Mainlist.ClassDatalist = TestData.GetClassInfos();
            //Mainlist.Update();


        }
        private void MainlistUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Mainlist.ClassDatalist = TestData.GetClassInfos(1);
            //Mainlist.ClassDatalist.RemoveAt(0);
            //Mainlist.Update();

            TestFunctions.xmlparsetest();
        }

        private void TimeSelectControl_Loaded(object sender, RoutedEventArgs e)
        {

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
            MainSchedule.ClassData = TestData.GetClassInfoPlus();
            MainSchedule.UpDate();
        }
    }
}
