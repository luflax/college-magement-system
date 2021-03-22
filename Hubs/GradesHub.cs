using System;
using System.Collections.Generic;
using System.Linq;
using College_Management_System.Dtos;
using College_Management_System.Models;
using College_Management_System.Repositories;
using College_Management_System.UnitOfWork;
using Microsoft.AspNet.SignalR;

namespace College_Management_System.Hubs
{
    public class GradesHub : Hub
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Subject> subjectRepository;
        private readonly IRepository<SubjectStudent> subjectStudentRepository;
        private readonly IRepository<Student> studentRepository;

        public GradesHub(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            subjectRepository = unitOfWork.GetRepository<Subject>();
            subjectStudentRepository = unitOfWork.GetRepository<SubjectStudent>();
            studentRepository = unitOfWork.GetRepository<Student>();
        }

        // Includes caller into the subject group
        public void JoinSubject(string subjectId)
        {
            Groups.Add(Context.ConnectionId, subjectId);

            var subject = subjectRepository.GetById(Convert.ToInt32(subjectId));
            if (subject != null)
            {
                Clients.Caller.LoadGrades(getGradesFromSubject(subject));
            }
        }

        // Updates a grade
        public void UpdateGrade(SubjectStudentDto student)
        {
            if (student != null)
            {
                var subject = subjectRepository.GetById(Convert.ToInt32(student.SubjectId));
                if (subject != null)
                {
                    subject.SubjectStudents = subject.SubjectStudents.Select(e =>
                    {
                        if (e.Id == student.Id)
                        {
                            e.Grade = student.StudentGrade;
                        }

                        return e;
                    }).ToList();
                    subjectRepository.Edit(subject);
                    unitOfWork.SaveChanges();

                    Clients.Group(student.SubjectId.ToString()).LoadGrades(getGradesFromSubject(subject));
                }
            }
        }

        // Adds a new grade to the subject
        public void AddGrade(SubjectStudentDto student)
        {
            if (student != null)
            {
                var subject = subjectRepository.GetById(Convert.ToInt32(student.SubjectId));
                if (subject != null)
                {
                    if (subject.SubjectStudents.Any(e => e.StudentId == student.StudentId))
                    {
                        return;
                    }

                    var studentEntity = studentRepository.GetById(student.StudentId);
                    subject.SubjectStudents.Add(new SubjectStudent
                    {
                        StudentId = student.StudentId,
                        Student = studentEntity,
                        SubjectId = student.SubjectId,
                        Grade = student.StudentGrade
                    });
                    subjectRepository.Edit(subject);
                    unitOfWork.SaveChanges();

                    Clients.Group(student.SubjectId.ToString()).LoadGrades(getGradesFromSubject(subject));
                }
            }
        }

        // Deletes a grade from the subject
        public void DeleteGrade(int subjectId, int gradeId)
        {
            var subjectStudent = subjectStudentRepository.GetById(gradeId);
            if (subjectStudent != null)
            {
                subjectStudentRepository.Delete(subjectStudent);
                unitOfWork.SaveChanges();

                var subject = subjectRepository.GetById(subjectId);
                if (subject != null)
                {
                    Clients.Group(subjectId.ToString()).LoadGrades(getGradesFromSubject(subject));
                }
            }
        }

        // Maps all subject grades
        private List<SubjectStudentDto> getGradesFromSubject(Subject subject)
        {
            return subject.SubjectStudents.Select(e => e.ToSubjectStudentDto()).ToList();
        }
    }
}