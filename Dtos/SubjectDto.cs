using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using College_Management_System.Models;

namespace College_Management_System.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeacherDto Teacher { get; set; }
    }

    public static class SubjectDtoExtension
    {
        public static SubjectDto ToSubjectDto(this Subject subject)
        {
            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Teacher = subject.Teacher.ToTeacherDto()
            };
        }
    }
}