using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using College_Management_System.Models;

namespace College_Management_System.Dtos
{
    public class SubjectOverviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int GradeAverage { get; set; }
    }

    public static class SubjectOverviewDtoExtension
    {
        public static SubjectOverviewDto ToSubjectOverviewDto(this Subject subject)
        {
            return new SubjectOverviewDto
            {
                Id = subject.Id,
                Name = subject.Name,
                TeacherName = subject.Teacher != null ? subject.Teacher.User.Name : "Missing",
                GradeAverage = subject.SubjectStudents.Any()
                    ? subject.SubjectStudents.Aggregate(0, (i, student) => i += student.Grade.GetValueOrDefault()) /
                      subject.SubjectStudents.Count()
                    : 0
            };
        }
    }
}