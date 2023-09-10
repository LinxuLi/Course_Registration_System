using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace Lab7.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; }

        public Student(string name)
        {
            var random = new Random();
            Id = random.Next(100000, 999999);
            Name = name;
            RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }

        public int TotalWeeklyHours()
        {
            int total = 0;
            foreach (var course in RegisteredCourses)
            {
                total += course.WeeklyHours;
            }
            return total;
        }
    }
}
