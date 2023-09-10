using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

public class CoopStudent : Student
{
    public static int MaxWeeklyHours { get; set; }
    public static int MaxNumOfCourses { get; set; }

    public CoopStudent(string name) : base(name)
    {
    }

    public override void RegisterCourses(List<Course> selectedCourses)
    {
        if (selectedCourses.Count > MaxNumOfCourses)
        {
            throw new Exception("Your selection exceeds the maximum number of course:2");
        }

        int totalHours = selectedCourses.Sum(course => course.WeeklyHours);
        if (totalHours > MaxWeeklyHours)
        {
            throw new Exception("Your selection exceeds the maximum weekly hours:4");
        }

        base.RegisterCourses(selectedCourses);
    }

    public override string ToString()
    {
        return $"{Id} – {Name} (Coop)";
    }
}
