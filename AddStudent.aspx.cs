using System; 
using System.Collections.Generic; 
using System.Web.UI; 
using lab7.Models; 
using Lab7.Models; 

namespace Lab7
{
    public partial class AddStudent : Page 
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!IsPostBack) // If it's not a postback (initial request)
            {
                Session["Students"] = new List<Student>(); // Initialize an empty list of students in the session
            }

            BindData(); 
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            // Check Student Name or Student Type is empty
            if (string.IsNullOrEmpty(StudentName.Text) || string.IsNullOrEmpty(StudentType.SelectedValue))
                return;

            // Retrieve the list of students from the session
            var students = (List<Student>)Session["Students"];

            // Switch statement based on the selected student type, creating an instance of the corresponding class
            switch (StudentType.SelectedValue)
            {
                case "FulltimeStudent":
                    students.Add(new FulltimeStudent(StudentName.Text));
                    break;
                case "ParttimeStudent":
                    students.Add(new ParttimeStudent(StudentName.Text));
                    break;
                case "CoopStudent":
                    students.Add(new CoopStudent(StudentName.Text));
                    break;
            }

            Session["Students"] = students; // Update the session with the modified list of students

            // Clear the Student Name field and reset the Student Type dropdown index
            StudentName.Text = string.Empty;
            StudentType.SelectedIndex = 0;

            BindData(); 
        }

        private void BindData()
        {
            var students = (List<Student>)Session["Students"]; // Retrieve the list of students from the session
            StudentsGrid.DataSource = students; // Set the data source of the grid to the students list
            StudentsGrid.DataBind(); 
        }
    }
}
