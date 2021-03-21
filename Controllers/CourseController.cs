using College_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using College_Management_System.Repositories;
using College_Management_System.UnitOfWork;

namespace College_Management_System.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Course> courseRepository;

        public CourseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.courseRepository = unitOfWork.GetRepository<Course>();
        }

        // GET Course/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET Course/GetCourse
        public JsonResult GetCourse()
        {
            var courses = courseRepository.GetAll();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        // POST Course/CreateCourse
        public JsonResult CreateCourse(Course course)
        { 
            if (course != null)
            {
                courseRepository.Add(course);
                unitOfWork.SaveChanges();

                return Json(new {success = true});
            }
            return Json(new { success = false });
        }

        // PUT Course/UpdateCourse
        public JsonResult UpdateCourse(Course course)
        {
            if (course != null)
            {
                courseRepository.Edit(course);
                unitOfWork.SaveChanges();

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // DELETE Course/DeleteCourse
        public JsonResult DeleteCourse(Course course)
        {
            if (course != null)
            {
                courseRepository.Delete(course);
                unitOfWork.SaveChanges();

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}