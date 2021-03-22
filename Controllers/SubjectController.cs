using System.Linq;
using System.Web.Mvc;
using College_Management_System.Dtos;
using College_Management_System.Hubs;
using College_Management_System.Models;
using College_Management_System.Repositories;
using College_Management_System.UnitOfWork;
using Microsoft.AspNet.SignalR;

namespace College_Management_System.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Subject> subjectRepository;
        private IHubContext hubContext;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            subjectRepository = unitOfWork.GetRepository<Subject>();
            this.hubContext = GlobalHost.ConnectionManager.GetHubContext<GradesHub>();
        }

        // GET Subject/ViewSubject/Id
        public ActionResult ViewSubject(int? id)
        {
            if (id == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var subject = subjectRepository.GetById(id.GetValueOrDefault());
            if (subject == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            ViewBag.Subject = subject.ToSubjectDto();
            return View();
        }

        // GET Subject/GetSubject/{subjectId}
        public JsonResult GetSubject(int? id)
        {
            if (id == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var subject = subjectRepository.GetById((int) id);

            if (subject == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            return Json(subject.ToSubjectDto(), JsonRequestBehavior.AllowGet);
        }

        // GET Subject/GetSubjects/{courseId}
        public JsonResult GetSubjects(int? id)
        {
            if (id == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var subjects = subjectRepository.GetMany(e => e.CourseId == id).ToList();

            if (!subjects.Any())
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var subjectsDtos = subjects.Select(subject => subject.ToSubjectOverviewDto());

            return Json(subjectsDtos, JsonRequestBehavior.AllowGet);
        }


        // POST Subject/CreateSubject
        public JsonResult CreateSubject(Subject subject)
        {
            if (subject != null)
            {
                subjectRepository.Add(subject);
                unitOfWork.SaveChanges();

                return Json(new {success = true});
            }

            return Json(new {success = false});
        }

        // POST Subject/UpdateSubject
        public JsonResult UpdateSubject(Subject subject)
        {
            if (subject != null)
            {
                subjectRepository.Edit(subject);
                unitOfWork.SaveChanges();

                this.hubContext.Clients.Group(subject.Id.ToString()).SubjectUpdate(subject);

                return Json(new {success = true});
            }

            return Json(new {success = false});
        }

        // POST Subject/DeleteSubject
        public JsonResult DeleteSubject(Subject subject)
        {
            if (subject != null)
            {
                var currentSubject = subjectRepository.GetById(subject.Id);
                if (currentSubject != null)
                {
                    subjectRepository.Delete(currentSubject);
                    unitOfWork.SaveChanges();
                }

                return Json(new {success = true});
            }

            return Json(new {success = false});
        }
    }
}