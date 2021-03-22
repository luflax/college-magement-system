using System;
using System.Linq;
using System.Web.Mvc;
using College_Management_System.Dtos;
using College_Management_System.Models;
using College_Management_System.Repositories;
using College_Management_System.UnitOfWork;

namespace College_Management_System.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IRepository<User> userRepository;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            teacherRepository = unitOfWork.GetRepository<Teacher>();
            userRepository = unitOfWork.GetRepository<User>();
        }

        // GET Teacher/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET Teacher/GetTeachers
        public JsonResult GetTeachers()
        {
            var teachers = teacherRepository.GetAll().Select(e => e.ToTeacherDto());

            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        // POST Teacher/CreateTeacher
        public JsonResult CreateTeacher(TeacherDto teacher)
        {
            if (teacher != null)
            {
                teacherRepository.Add(teacher.ToTeacher());
                unitOfWork.SaveChanges();

                return Json(new {success = true});
            }

            return Json(new {success = false});
        }

        // POST Teacher/UpdateTeacher
        public JsonResult UpdateTeacher(TeacherDto teacher)
        {
            if (teacher != null)
            {
                var currentTeacher = teacherRepository.GetById(teacher.Id);
                if (currentTeacher != null)
                {
                    currentTeacher.Salary = Convert.ToDecimal(teacher.Salary);
                    currentTeacher.User.BirthDay = DateTime.Parse(teacher.BirthDay);
                    currentTeacher.User.Name = teacher.Name;

                    teacherRepository.Edit(currentTeacher);
                    unitOfWork.SaveChanges();

                    return Json(new {success = true});
                }
            }

            return Json(new {success = false});
        }

        // POST Teacher/DeleteTeacher
        public JsonResult DeleteTeacher(TeacherDto teacher)
        {
            if (teacher != null)
            {
                var currentTeacher = teacherRepository.GetById(teacher.Id);
                if (currentTeacher != null)
                {
                    userRepository.Delete(currentTeacher.User);
                    unitOfWork.SaveChanges();

                    return Json(new {success = true});
                }
            }

            return Json(new {success = false});
        }
    }
}