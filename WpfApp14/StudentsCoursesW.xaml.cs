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

namespace WpfApp14
{
    public partial class StudentsCoursesW : Window
    {
        private UniversityEntities context = new UniversityEntities();
        
        public StudentsCoursesW()
        {
            InitializeComponent();
            StudentsCoursesGrd.ItemsSource = context.StudentsCoursesView2.ToList();

            ComboBoxStudents.ItemsSource = context.Students.ToList();
            ComboBoxStudents.DisplayMemberPath = "StudentSurname";

            ComboBoxCourses.ItemsSource = context.Courses.ToList();
            ComboBoxCourses.DisplayMemberPath = "Title";

        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxStudents.SelectedItem == null || ComboBoxCourses.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите студента и курс.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Students selectedStudent = (Students)ComboBoxStudents.SelectedItem;
            Courses selectedCourse = (Courses)ComboBoxCourses.SelectedItem;

            if (selectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("Пожалуйста, выберите студента и курс.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StudentsCourses newStudentCourse = new StudentsCourses()
            {
                Student_ID = selectedStudent.ID_Student,
                Course_ID = selectedCourse.ID_Course
            };
            context.StudentsCourses.Add(newStudentCourse);
            context.SaveChanges();

            StudentsCoursesGrd.ItemsSource = context.StudentsCoursesView2.ToList();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            StudentsCoursesView2 selectedStudentCourseView = (StudentsCoursesView2)StudentsCoursesGrd.SelectedItem;

            if (selectedStudentCourseView != null)
            {
                Students selectedStudent = (Students)ComboBoxStudents.SelectedItem;
                Courses selectedCourse = (Courses)ComboBoxCourses.SelectedItem;

                StudentsCourses selectedStudentCourse = context.StudentsCourses.Find(selectedStudentCourseView.ID);

                if (selectedStudent != null && selectedCourse != null)
                {
                    selectedStudentCourse.Student_ID = selectedStudent.ID_Student;
                    selectedStudentCourse.Course_ID = selectedCourse.ID_Course;
                    context.SaveChanges();

                    StudentsCoursesGrd.ItemsSource = context.StudentsCoursesView2.ToList();
                }
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            StudentsCoursesView2 selectedStudentCourseView = (StudentsCoursesView2)StudentsCoursesGrd.SelectedItem;

            if (selectedStudentCourseView != null)
            {
                StudentsCourses selectedStudentCourse = context.StudentsCourses.Find(selectedStudentCourseView.ID);

                if (selectedStudentCourse != null)
                {
                    context.StudentsCourses.Remove(selectedStudentCourse);
                    context.SaveChanges();

                    StudentsCoursesGrd.ItemsSource = context.StudentsCoursesView2.ToList();
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


    }
}
