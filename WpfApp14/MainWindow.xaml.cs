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

namespace WpfApp14
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Students_Click(object sender, RoutedEventArgs e)
        {
            StudentsW window1 = new StudentsW();
            window1.ShowDialog();
            if (window1.DialogResult == false)
            {
                window1.Close();
            }
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            CoursesW window2 = new CoursesW();
            window2.ShowDialog();
            if (window2.DialogResult == false)
            {
                window2.Close();
            }
        }

        private void StudentsCourses_Click(object sender, RoutedEventArgs e)
        {
            StudentsCoursesW window2 = new StudentsCoursesW();
            window2.ShowDialog();
            if (window2.DialogResult == false)
            {
                window2.Close();
            }
        }


    }
}
