using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp14
{
    public partial class StudentsW : Window
    {
        private UniversityEntities context = new UniversityEntities();
        public StudentsW()
        {
            InitializeComponent();
            StudentsGrd.ItemsSource = context.Students.ToList();
            StudentsGrd.SelectionChanged += StudentsGrd_SelectionChanged;
        }
        private void StudentsGrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (StudentsGrd.SelectedItem != null)
            {
               
                Students selectedStudent = (Students)StudentsGrd.SelectedItem;

                TextBoxSurname.Text = selectedStudent.StudentSurname;
                TextBoxName.Text = selectedStudent.StudentName;
                TextBoxMiddleName.Text = selectedStudent.StudentMiddleName;
                TextBoxAge.Text = selectedStudent.Age.ToString();
                TextBoxEmail.Text = selectedStudent.Email;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxSurname.Text) || string.IsNullOrWhiteSpace(TextBoxName.Text) ||
                string.IsNullOrWhiteSpace(TextBoxAge.Text) || string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все текстовые поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Students newStudent = new Students()
            {
                StudentSurname = TextBoxSurname.Text,
                StudentName = TextBoxName.Text,
                StudentMiddleName = TextBoxMiddleName.Text,
                Age = Convert.ToInt32(TextBoxAge.Text),
                Email = TextBoxEmail.Text
            };

            context.Students.Add(newStudent);
            context.SaveChanges();

            StudentsGrd.ItemsSource = context.Students.ToList();

            UpdateStudentsCourses();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxSurname.Text) || string.IsNullOrWhiteSpace(TextBoxName.Text) ||
                string.IsNullOrWhiteSpace(TextBoxAge.Text) || string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все текстовые поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Students selectedStudent = (Students)StudentsGrd.SelectedItem;

            if (selectedStudent != null)
            {
                selectedStudent.StudentSurname = TextBoxSurname.Text;
                selectedStudent.StudentName = TextBoxName.Text;
                selectedStudent.StudentMiddleName = TextBoxMiddleName.Text;
                selectedStudent.Age = Convert.ToInt32(TextBoxAge.Text);
                selectedStudent.Email = TextBoxEmail.Text;

                context.SaveChanges();

                StudentsGrd.ItemsSource = context.Students.ToList();

                UpdateStudentsCourses();
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Students selectedStudent = (Students)StudentsGrd.SelectedItem;

            if (selectedStudent != null)
            {
                RemoveStudentFromCourses(selectedStudent.ID_Student);

                context.Students.Remove(selectedStudent);
                context.SaveChanges();

                StudentsGrd.ItemsSource = context.Students.ToList();
            }
        }

        private void RemoveStudentFromCourses(int studentId)
        {
            var studentCourses = context.StudentsCourses.Where(sc => sc.Student_ID == studentId).ToList();
            context.StudentsCourses.RemoveRange(studentCourses);
            context.SaveChanges();
        }


        private void UpdateStudentsCourses()
        {
            foreach (var studentCourse in context.StudentsCourses.ToList())
            {
                if (!context.Students.Any(s => s.ID_Student == studentCourse.Student_ID) ||
                    !context.Courses.Any(c => c.ID_Course == studentCourse.Course_ID))
                {
                    context.StudentsCourses.Remove(studentCourse);
                }
            }

            foreach (var student in context.Students)
            {
                var studentCourses = context.StudentsCourses
                    .Where(sc => sc.Student_ID == student.ID_Student)
                    .Select(sc => sc.Course_ID)
                    .ToList();

                foreach (var courseId in studentCourses)
                {
                    if (!context.StudentsCourses.Any(sc => sc.Student_ID == student.ID_Student && sc.Course_ID == courseId))
                    {
                        context.StudentsCourses.Add(new StudentsCourses()
                        {
                            Student_ID = student.ID_Student,
                            Course_ID = courseId
                        });
                    }
                }
            }

            context.SaveChanges();
        }
        private void TextBoxAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9]+$"))
            {
                e.Handled = true;
            }
        }
        private void TextBoxSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int maxLength = 50;

                if (textBox.Text.Length >= maxLength)
                {
                    e.Handled = true;
                    return; 
                }

                foreach (char c in e.Text)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        e.Handled = true;
                        return; 
                    }
                }
            }
        }

        private void TextBoxEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int maxLength = 100; 
                if (textBox.Text.Length >= maxLength)
                {
                    e.Handled = true; 
                }
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


    }
}
