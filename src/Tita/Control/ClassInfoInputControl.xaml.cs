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
    /// ClassInfoInputControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassInfoInputControl : UserControl
    {

        public ClassInfoInputControl()
        {
            InitializeComponent();
        }

        public ClassInfo GetResult()
        {
            string Name = name.Text;
            string Professor = professor.Text;
            string m = division.Text;
            int Division = Int32.Parse(m);
            if (credit.SelectedIndex == 0)
            {
                throw new ValueException("항목을 선택하세요.");
            }

            string val = ((ComboBoxItem)credit.SelectedItem).Content.ToString();
            bool result = Int32.TryParse(val, out int c);
            if (!result)
            {
                throw new ValueException("TryParse could not parse");
            }

            //ClassInfo tmp = new ClassInfo(Name, Division, time, Professor, c);
            ClassInfo tmp = new ClassInfo();
            return tmp;
        }

  

        public void GetFocusOnName(object sender, RoutedEventArgs e)
        {
            name.Text = "";
        }
        public void GetFocusOndivision(object sender, RoutedEventArgs e)
        {
            division.Text = "";
        }
        public void GetFocusOnprofessor(object sender, RoutedEventArgs e)
        {
            professor.Text = "";
        }
        public void GetFocusOncredit(object sender, RoutedEventArgs e)
        {
            credit.Text = "";
        }
    }
}
