using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace lab7.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = selectedCourses.Sum(course => course.WeeklyHours);
            if (totalHours > MaxWeeklyHours)
            {
                throw new Exception("Your selection exceeds the maximum weekly hours:16");
            }
            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} – {Name} (Full time)";
        }
    }
}
