using System.Data.SqlClient;

namespace WpfApp14
{


    partial class UniversityDataSet
    {
    }
}

namespace WpfApp14.UniversityDataSetTableAdapters
{
    partial class StudentsCoursesTableAdapter
    {
        public int DeleteByCourseID(int courseID)
        {
            using (var connection = new SqlConnection(this.Connection.ConnectionString))
            {
                string deleteStatement = "DELETE FROM StudentsCourses WHERE Course_ID = @CourseID";
                SqlCommand command = new SqlCommand(deleteStatement, connection);
                command.Parameters.AddWithValue("@CourseID", courseID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public partial class CoursesTableAdapter {
    }
}
