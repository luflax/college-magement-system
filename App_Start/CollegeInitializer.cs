using System;
using System.Collections.Generic;
using College_Management_System.Models;

namespace College_Management_System.App_Start
{
    public class CollegeInitializer : System.Data.Entity.DropCreateDatabaseAlways<LDBEntities>
    {
        protected override void Seed(LDBEntities context)
        {
            var students = new List<Student>
            {
            new Student{User= new User{Name = "Luiz Flavio", BirthDay = DateTime.Parse("04/14/1998")}, RegistrationNumber = 10001},
            new Student{User= new User{Name = "Augusto Jardim", BirthDay = DateTime.Parse("04/15/1998")}, RegistrationNumber = 10002},
            new Student{User= new User{Name = "Denise Costa", BirthDay = DateTime.Parse("04/16/1998")}, RegistrationNumber = 10003},
            new Student{User= new User{Name = "João Caetano", BirthDay = DateTime.Parse("04/17/1998")}, RegistrationNumber = 10004},
            new Student{User= new User{Name = "Mark Keeta", BirthDay = DateTime.Parse("04/18/1998")}, RegistrationNumber = 10005},
            new Student{User= new User{Name = "Nikita", BirthDay = DateTime.Parse("04/19/1998")}, RegistrationNumber = 10006},
            new Student{User= new User{Name = "Rodrigo Bastião", BirthDay = DateTime.Parse("04/20/1998")}, RegistrationNumber = 10007},
            new Student{User= new User{Name = "Lucas Silva", BirthDay = DateTime.Parse("03/10/1998")}, RegistrationNumber = 10008},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{Name = "Business"},
                new Course{Name = "Social Sciences"},
                new Course{Name = "Psychology"},
                new Course{Name = "Computer Science"}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher{User= new User{Name = "Mark Hoffman", BirthDay = DateTime.Parse("04/14/1968")}, Salary = 2000},
                new Teacher{User= new User{Name = "Monica Rambeau", BirthDay = DateTime.Parse("04/14/1975")}, Salary = 3000},
                new Teacher{User= new User{Name = "Monica Silva", BirthDay = DateTime.Parse("04/14/1955")}, Salary = 4000},
                new Teacher{User= new User{Name = "Erick Patrick", BirthDay = DateTime.Parse("04/14/1989")}, Salary = 1500}
            };

            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
                new Subject{Name = "Software Quality", Course = courses[3], Teacher = teachers[1]},
                new Subject{Name = "Software Quality II", Course = courses[2], Teacher = teachers[2]},
                new Subject{Name = "Software Engineering", Course = courses[1], Teacher = teachers[3]},
                new Subject{Name = "Laws", Course = courses[1], Teacher = teachers[3]},
                new Subject{Name = "Mobile Development", Course = courses[0], Teacher = teachers[0]}
            };

            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var subjectStudents = new List<SubjectStudent>
            {
                new SubjectStudent{Student = students[1], Subject = subjects[2], Grade = 80},
                new SubjectStudent{Student = students[1], Subject = subjects[1], Grade = 78},
                new SubjectStudent{Student = students[1], Subject = subjects[3], Grade = 60},
                new SubjectStudent{Student = students[1], Subject = subjects[0], Grade = 88},
                new SubjectStudent{Student = students[2], Subject = subjects[2], Grade = 77},
                new SubjectStudent{Student = students[2], Subject = subjects[1], Grade = 98},
                new SubjectStudent{Student = students[2], Subject = subjects[3], Grade = 100},
                new SubjectStudent{Student = students[3], Subject = subjects[0], Grade = 87},
            };

            subjectStudents.ForEach(s => context.SubjectStudents.Add(s));
            context.SaveChanges();
        }
    }
}