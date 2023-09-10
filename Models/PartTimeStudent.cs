using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace lab7.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        public ParttimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception("Your selection exceeds the maximum number of course:3");
            }
            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} – {Name} (Part time)";
        }
    }
}
