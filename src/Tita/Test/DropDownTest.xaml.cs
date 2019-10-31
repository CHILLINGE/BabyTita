using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Tita.Algorithm;

namespace Tita
{
    /// <summary>
    /// DropDownTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DropDownTest : Window
    {
        public DropDownTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataFile file = new DataFile("subjects.xml");
            var infos = file.LoadClassInfo();

            ClassGroup root = new ClassGroup();
            var group = new ClassGroup();
            foreach (var i in infos.Groups["컴퓨터정보공학부"])
            {
                group.AddGroup(new ClassInfoPlus(i, group));
            }
            group.SelectCount = 1;
            root.AddGroup(group);

            BruteForceClassSelector algo = new BruteForceClassSelector();
            var result = algo.Calculate(root);
            Debug.Write(result);
        }
    }
}
