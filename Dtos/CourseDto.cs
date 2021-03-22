using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using College_Management_System.Models;

namespace College_Management_System.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeachersCount { get; set; }
        public int StudentsCount { get; set; }
        public int GradeAverage { get; set; }
    }

    public static class CourseDtoExtension
    {
        public static CourseDto ToCourseDto(this Course course)
        {
            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name
            };
        }
    }
}