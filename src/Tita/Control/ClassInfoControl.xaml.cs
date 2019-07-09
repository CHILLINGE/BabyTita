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
    /// ClassInfoControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassInfoControl : UserControl
    {

        private ClassInfo info;
        private ClassInfoPlus infoPlus;

        public ClassInfo Info
        {
            get => info;
            set
            {
                info = value;
                UpdateInfoChanged();
            }
        }

        public ClassInfoPlus InfoPlus {
            get => infoPlus;
            set { infoPlus = value; UpdateInfoPlusChanged(); }
        }

        public bool HasInfoPlus
        {
            get { return infoPlus != null; }
            set { if (!value) { infoPlus = null; } }
        }




        public string ClassName
        {
            get { return (string)GetValue(ClassNameProperty); }
            set { SetValue(ClassNameProperty, value); }
        }
        public static readonly DependencyProperty ClassNameProperty =
            DependencyProperty.Register("ClassName", typeof(string), typeof(ClassInfoControl), new PropertyMetadata("SubjectName"));


        public int ClassCredit
        {
            get { return (int)GetValue(ClassCreditProperty); }
            set { SetValue(ClassCreditProperty, value); }
        }
        public static readonly DependencyProperty ClassCreditProperty =
            DependencyProperty.Register("ClassCredit", typeof(int), typeof(ClassInfoControl), new PropertyMetadata(0));


        public int ClassDivision
        {
            get { return (int)GetValue(ClassDivisionProperty); }
            set { SetValue(ClassDivisionProperty, value); }
        }
        public static readonly DependencyProperty ClassDivisionProperty =
            DependencyProperty.Register("ClassDivision", typeof(int), typeof(ClassInfoControl), new PropertyMetadata(0));


        public string ClassProfessor
        {
            get { return (string)GetValue(ClassProfessorProperty); }
            set { SetValue(ClassProfessorProperty, value); }
        }
        public static readonly DependencyProperty ClassProfessorProperty =
            DependencyProperty.Register("ClassProfessor", typeof(string), typeof(ClassInfoControl), new PropertyMetadata("Prof"));


        public string ClassMajor
        {
            get { return (string)GetValue(ClassMajorProperty); }
            set { SetValue(ClassMajorProperty, value); }
        }
        public static readonly DependencyProperty ClassMajorProperty =
            DependencyProperty.Register("ClassMajor", typeof(string), typeof(ClassInfoControl), new PropertyMetadata("Major"));




        public int ClassPreference
        {
            get { return (int)GetValue(ClassPreferenceProperty); }
            set { SetValue(ClassPreferenceProperty, value); }
        }
        public static readonly DependencyProperty ClassPreferenceProperty =
            DependencyProperty.Register("ClassPreference", typeof(int), typeof(ClassInfoControl), new PropertyMetadata(2, 
                (obj,e) => {
                    ClassInfoControl ctl = obj as ClassInfoControl;
                    if (ctl.HasInfoPlus)
                    {
                        if (e.OldValue != e.NewValue)
                        {
                            ctl.infoPlus.Preference = (int)e.NewValue;
                        }
                    }
                }));




        public ClassInfoControl()
        {
            InitializeComponent();

            infoPlus = null;

            UpdateInfoPlusChanged();
        }

        public ClassInfoControl(ClassInfo info) : this()
        {

            Info = info;
            UpdateInfoChanged();

        }


        public void UpdateInfoChanged()
        {
            ClassName = Info.Name;
            ClassDivision = Info.Division;
            ClassCredit = Info.Credit;
            ClassProfessor = Info.Professor;
            ClassMajor = Info.Major;
        }

        public void UpdateInfoPlusChanged()
        {
            if (HasInfoPlus)
            {
                preferenceSlider.Visibility = Visibility.Visible;
                preferenceSlider.Value = infoPlus.Preference;
            }
            else
            {
                preferenceSlider.Visibility = Visibility.Collapsed;
            }
        }

    }
}
