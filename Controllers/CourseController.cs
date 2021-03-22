using System.Linq;
using System.Web.Mvc;
using College_Management_System.Dtos;
using College_Management_System.Models;
using College_Management_System.Repositories;
using College_Management_System.UnitOfWork;

namespace College_Management_System.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<Subject> subjectRepository;

        public CourseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            courseRepository = unitOfWork.GetRepository<Course>();
            subjectRepository = unitOfWork.GetRepository<Subject>();
        }

        // GET Course/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET Course/ViewCourse/Id
        public ActionResult ViewCourse(int? id)
        {
            if (id == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var course = courseRepository.GetById(id.GetValueOrDefault());
            if (course == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            ViewBag.Course = course;
            return View();
        }

        // GET Course/GetCourses
        [HttpGet]
        public JsonResult GetCourses()
        {
            // Retrieves all courses
            var courses = courseRepository.GetAll();

            // Maps course entities to DTO
            var coursesDto = courses.Select(course =>
            {
                // Gets course's subjects
                var subjects = subjectRepository.GetMany(e => e.CourseId == course.Id).ToList();

                // Calculates average grade for each subject
                var gradesSums = subjects.Select(e =>
                {
                    var studentsGrades = e.SubjectStudents.Where(student => student.Grade != null);
                    if (!studentsGrades.Any())
                    {
                        return 0;
                    }

                    var gradesSum =
                        studentsGrades.Aggregate(0, (a, student) => a += (int) student.Grade);
                    return gradesSum / studentsGrades.Count();
                });

                var courseDto = course.ToCourseDto();
                // Sums subject's students count
                courseDto.StudentsCount = subjects.Aggregate(0, (i, subject) => subject.SubjectStudents.Count());

                // Counts subjects with an assigned teacher
                courseDto.TeachersCount = subjects.Select(e => e.Teacher != null).Count();

                // Sums all grades sums retrieved before and calculate the average
                courseDto.GradeAverage =
                    gradesSums.Any() ? gradesSums.Aggregate(0, (a, v) => a += v) / gradesSums.Count() : 0;

                return courseDto;
            }).ToList();

            return Json(coursesDto, JsonRequestBehavior.AllowGet);
        }

        // POST Course/CreateCourse
        [HttpPost]
        public JsonResult CreateCourse(Course course)
        {
            if (course != null)
            {
                courseRepository.Add(course);
                unitOfWork.SaveChanges();

                return Json(new {success = true});
            }

            return Json(new {success = false});
        }

        // POST Course/UpdateCourse
        public JsonResult UpdateCourse(Course course)
        {
            if (course != null)
            {
                courseRepository.Edit(course);
                unitOfWork.SaveChanges();

                return Json(new {success = true});
            }

            return Json(new {success = false});
        }

        // POST Course/DeleteCourse
        public JsonResult DeleteCourse(Course course)
        {
            if (course != null)
            {
                var currentCourse = courseRepository.GetById(course.Id);
                if (currentCourse != null)
                {
                    courseRepository.Delete(currentCourse);
                    unitOfWork.SaveChanges();
                }

                return Json(new {success = true});
            }

            return Json(new {success = false});
        }
    }
}