using System;
using System.Linq;
using System.Web.Mvc;
using College_Management_System.Dtos;
using College_Management_System.Models;
using College_Management_System.Repositories;
using College_Management_System.UnitOfWork;

namespace College_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<User> userRepository;

        public StudentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            studentRepository = unitOfWork.GetRepository<Student>();
            userRepository = unitOfWork.GetRepository<User>();
        }

        // GET Student/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET Student/GetStudents
        public JsonResult GetStudents()
        {
            var students = studentRepository.GetAll().Select(e => e.ToStudentDto());

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        // POST Student/CreateStudent
        public JsonResult CreateStudent(StudentDto student)
        { 
            if (student != null)
            {
                studentRepository.Add(student.ToNewStudent());
                unitOfWork.SaveChanges();

                return Json(new {success = true});
            }
            return Json(new { success = false });
        }

        // POST Student/UpdateStudent
        public JsonResult UpdateStudent(StudentDto student)
        {
            if (student != null)
            {
                var currentStudent = studentRepository.GetById(student.Id);
                if (currentStudent != null)
                {
                    currentStudent.RegistrationNumber = student.RegistrationNumber;
                    currentStudent.User.BirthDay = DateTime.Parse(student.BirthDay);
                    currentStudent.User.Name = student.Name;

                    studentRepository.Edit(currentStudent);
                    unitOfWork.SaveChanges();

                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        // POST Student/DeleteStudent
        public JsonResult DeleteStudent(StudentDto student)
        {
            if (student != null)
            {
                var currentStudent = studentRepository.GetById(student.Id);
                if (currentStudent != null)
                {
                    userRepository.Delete(currentStudent.User);
                    unitOfWork.SaveChanges();

                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }
    }
}