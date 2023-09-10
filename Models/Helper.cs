using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

/// <summary>
/// Summary description for Helper
/// </summary>
namespace Lab6.Models
{
    public class Helper
    {
        public static List<Course> GetAvailableCourses()
        {
            List<Course> courses = new List<Course>();

            Course course = new Course("CST8282", "Introduction to Database Systems - 4 hours perweek");
            course.WeeklyHours = 4;
            courses.Add(course);

            course = new Course("CST8253", "Web Programming II - 2 hours perweek");
            course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8256", "Web Programming Language I - 5 hours perweek");
            course.WeeklyHours = 5;
            courses.Add(course);

            course = new Course("CST8255", "Web Imaging and Animations - 2 hours perweek");
            course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8254", "Network Operating System - 1 hours perweek");
            course.WeeklyHours = 1;
            courses.Add(course);

            course = new Course("CST2200", "Data Warehouse Design - 3 hours perweek");
            course.WeeklyHours = 3;
            courses.Add(course);

            course = new Course("CST2240", "Advance Database topics - 1 hours perweek");
            course.WeeklyHours = 1;
            courses.Add(course);

            return courses;
        }

        public static Course GetCourseByCode(string code)
        {
            foreach (Course c in GetAvailableCourses())
            {
                if (c.Code == code)
                {
                    return c;
                }
            }
            return null;
        }
    }
}