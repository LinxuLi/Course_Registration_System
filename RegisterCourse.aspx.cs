using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab6.Models;
using Lab7.Models;

namespace Lab7
{
    public partial class RegisterCourse : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var students = (List<Student>)Session["Students"];
                var studentSummaries = students.Select(s => new
                {
                    Id = s.Id,
                    Summary = $"{s.Id} - {s.Name} ({s.GetType().Name})"
                }).ToList();

                StudentDropdown.DataSource = studentSummaries;
                StudentDropdown.DataTextField = "Summary";
                StudentDropdown.DataValueField = "Id";

                StudentDropdown.DataValueField = "Id";
                StudentDropdown.DataBind();

                CourseCheckList.DataSource = Helper.GetAvailableCourses();
                CourseCheckList.DataTextField = "Title";
                CourseCheckList.DataValueField = "Code";
                CourseCheckList.DataBind();
            }
        }

        protected void StudentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var students = (List<Student>)Session["Students"];
            var student = students.FirstOrDefault(s => s.Id == int.Parse(StudentDropdown.SelectedValue));
            if (student != null)
            {
                SummaryLabel.Text = $"Registered {student.RegisteredCourses.Count} courses, {student.TotalWeeklyHours()} hours weekly";
                foreach (ListItem item in CourseCheckList.Items)
                {
                    item.Selected = student.RegisteredCourses.Exists(c => c.Code == item.Value);
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var students = (List<Student>)Session["Students"];
            var student = students.FirstOrDefault(s => s.Id == int.Parse(StudentDropdown.SelectedValue));
            if (student != null)
            {
                var selectedCourses = CourseCheckList.Items.Cast<ListItem>()
                    .Where(i => i.Selected)
                    .Select(i => Helper.GetCourseByCode(i.Value))
                    .ToList();

                if (!selectedCourses.Any())
                {
                    SummaryLabel.Text = "You need to select at least one course";
                    SummaryLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                try
                {
                    student.RegisterCourses(selectedCourses);
                    SummaryLabel.Text = $"Registered {student.RegisteredCourses.Count} courses, {student.TotalWeeklyHours()} hours weekly";
                    SummaryLabel.ForeColor = System.Drawing.Color.Black;
                }
                catch (Exception ex)
                {
                    SummaryLabel.Text = ex.Message;
                    SummaryLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

    }
}