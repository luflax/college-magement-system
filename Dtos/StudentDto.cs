using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using College_Management_System.Models;

namespace College_Management_System.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDay { get; set; }
        public int RegistrationNumber { get; set; }
    }

    public static class StudentDtoExtension
    {
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.User.Name,
                BirthDay = student.User.BirthDay.GetValueOrDefault().ToShortDateString(),
                RegistrationNumber = student.RegistrationNumber.GetValueOrDefault()
            };
        }

        public static Student ToNewStudent(this StudentDto studentDto)
        {
            return new Student
            {
                RegistrationNumber = studentDto.RegistrationNumber,
                User = new User
                {
                    Name = studentDto.Name,
                    BirthDay = DateTime.Parse(studentDto.BirthDay)
                }
            };
        }

        public static Student ToStudent(this StudentDto studentDto)
        {
            return new Student
            {
                Id = studentDto.Id,
                RegistrationNumber = studentDto.RegistrationNumber,
                User = new User
                {
                    Name = studentDto.Name,
                    BirthDay = DateTime.Parse(studentDto.BirthDay)
                }
            };
        }
    }
}