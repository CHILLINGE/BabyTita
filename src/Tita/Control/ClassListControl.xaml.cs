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
    /// ClassListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassListControl : UserControl
    {
        private List<ClassInfo> ListBackup;
        private Dictionary<int, int> BackUpDictionary;
        public List<ClassInfo> ClassDatalist { get; set; }

        public void Update()
        {
            //같은 list 주소를 나타낼때
            if (ListBackup == ClassDatalist)
            {
                //과목 직접 추가
               if (MainScroll.Children.Count < ClassDatalist.Count) 
                {
                    ClassInfoControl child = new ClassInfoControl();
                    child.Info = ClassDatalist[ClassDatalist.Count()];
                    child.VerticalAlignment = VerticalAlignment.Top;
                    child.HorizontalAlignment = HorizontalAlignment.Stretch;
                    child.Margin = new Thickness(5);

                    MainScroll.Children.Add(child);
                }
               //직접 추가한 과목 삭제
               else
                {
                    for (int i= MainScroll.Children.Count;i<0;i++)
                    {
                        BackUpDictionary.f(ClassDatalist[i].ID, i);
                        if (ClassDatalist[i].ID != )
                    }
                }
            }

            //list 주소가 다를 때
            else
            {
                MainScroll.Children.Clear();
                BackUpDictionary.Clear();
                for (int i = 0; i < ClassDatalist.Count; i++)
                {
                    //Dictionary에 과목id와 위치 저장
                    BackUpDictionary.Add(ClassDatalist[i].ID, i);

                    ClassInfoControl child = new ClassInfoControl();
                    child.Info = ClassDatalist[i];
                    child.VerticalAlignment = VerticalAlignment.Top;
                    child.HorizontalAlignment = HorizontalAlignment.Stretch;
                    child.Margin = new Thickness(5);

                    MainScroll.Children.Add(child);
                }
                ListBackup = ClassDatalist;

            }
        
        }


        public ClassListControl()
        {
            InitializeComponent();
            ListBackup = null;
            BackUpDictionary = new Dictionary<int, int>();


        }

    }
}
