using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using College_Management_System.Models;

namespace College_Management_System.Dtos
{
    public class SubjectStudentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string StudentName { get; set; }
        public string StudentBirthDay { get; set; }
        public int StudentRegistrationNumber { get; set; }
        public int StudentGrade { get; set; }
    }

    public static class SubjectSubjectDtoExtension
    {
        public static SubjectStudentDto ToSubjectStudentDto(this SubjectStudent subjectStudent)
        {
            return new SubjectStudentDto
            {
                Id = subjectStudent.Id,
                StudentName = subjectStudent.Student.User.Name,
                StudentBirthDay = subjectStudent.Student.User.BirthDay.GetValueOrDefault().ToShortDateString(),
                StudentGrade = subjectStudent.Grade.GetValueOrDefault(),
                StudentRegistrationNumber = subjectStudent.Student.RegistrationNumber.GetValueOrDefault()
            };
        }
    }
}