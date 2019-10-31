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
    /// Scaffold.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Scaffold : Window
    {
        public Scaffold()
        {
            InitializeComponent();
            Sample.Info = TestData.GetClassInfos()[0];

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sample.Info = TestData.GetClassInfos()[0];
            ClassGroup group = new ClassGroup();
            ClassInfoPlus info = new ClassInfoPlus(Sample.Info);
            group.AddGroup(info);

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
            //MainSchedule.ClassData = TestData.GetClassInfoPlus();
            //MainSchedule.UpDate();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            ClassTime time =  hello.GetClassTime();
         
            string name = classinfoinput.name.Text;
            string credit = classinfoinput.credit.Text;
            string professor = classinfoinput.professor.Text;
            string division = classinfoinput.division.Text;
            new ClassInfo(name, Int32.Parse(division), time, professor, Int32.Parse(credit));
            MessageBox.Show("추가되었습니다!");
        }

   
    }
}
