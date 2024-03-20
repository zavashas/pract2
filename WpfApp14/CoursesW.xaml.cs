using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp14.UniversityDataSetTableAdapters;
using static WpfApp14.UniversityDataSet;

namespace WpfApp14
{
    public partial class CoursesW : Window
    {
        private CoursesTableAdapter crs = new CoursesTableAdapter();
        private StudentsCoursesTableAdapter stdcrs = new StudentsCoursesTableAdapter();
        public CoursesW()
        {
            InitializeComponent();
            CoursesDataSet.ItemsSource = crs.GetData();
        }
        private void CoursesDataSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoursesDataSet.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)CoursesDataSet.SelectedItem;
                DataRow row = rowView.Row;

                TextBoxTitle.Text = row["Title"].ToString();
                TextBoxDescription.Text = row["DescriptionCourse"].ToString();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxTitle.Text))
            {
                MessageBox.Show("Пожалуйста, введите название курса.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            crs.Insert(TextBoxTitle.Text, TextBoxDescription.Text);
            CoursesDataSet.ItemsSource = crs.GetData();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDataSet.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите курс для изменения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TextBoxTitle.Text))
            {
                MessageBox.Show("Пожалуйста, введите название курса.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var selectedCourse = (CoursesRow)((DataRowView)CoursesDataSet.SelectedItem).Row;
            selectedCourse.Title = TextBoxTitle.Text;
            selectedCourse.DescriptionCourse = TextBoxDescription.Text;
            crs.Update(selectedCourse);
            CoursesDataSet.ItemsSource = crs.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCourse = (CoursesRow)((DataRowView)CoursesDataSet.SelectedItem).Row;
            stdcrs.DeleteByCourseID(selectedCourse.ID_Course);
            crs.DeleteQuery(selectedCourse.ID_Course, selectedCourse.Title);

            CoursesDataSet.ItemsSource = crs.GetData();
        }
        private void TextBoxTitle_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
