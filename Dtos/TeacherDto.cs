using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using College_Management_System.Models;

namespace College_Management_System.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDay { get; set; }
        public double Salary { get; set; }
    }

    public static class TeacherDtoExtension
    {
        public static TeacherDto ToTeacherDto(this Teacher teacher)
        {
            if (teacher == null)
            {
                return new TeacherDto { };
            }

            return new TeacherDto
            {
                Id = teacher.Id,
                Name = teacher.User.Name,
                BirthDay = teacher.User.BirthDay.GetValueOrDefault().ToShortDateString(),
                Salary = Convert.ToDouble(teacher.Salary.GetValueOrDefault())
            };
        }

        public static Teacher ToTeacher(this TeacherDto teacherDto)
        {
            return new Teacher
            {
                Id = teacherDto.Id,
                Salary = Convert.ToDecimal(teacherDto.Salary),
                User = new User
                {
                    Name = teacherDto.Name,
                    BirthDay = DateTime.Parse(teacherDto.BirthDay)
                }
            };
        }
    }
}