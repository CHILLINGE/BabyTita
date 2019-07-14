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
        public event EventHandler ElementAdd;


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
            foreach (ClassGroup g in group.Children)
            {
                ClassGroupControl GControl = new ClassGroupControl(g);
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
    }
}
