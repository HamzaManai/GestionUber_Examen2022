using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Web.Controllers
{
    public class CourseController : Controller
    {
        IUnitOfWork unitOfWork;
        ICourseService courseService;
        IService<Client> clientService;
        IService<Voiture> voitureService;
        IService<Chauffeur> chauffeurService;
        public CourseController(IUnitOfWork unitOfWork, ICourseService courseService,
            IService<Client> clientService, IService<Voiture> voitureService,
            IService<Chauffeur> chauffeurService)
        {
            this.courseService = courseService;
            this.unitOfWork = unitOfWork;
            this.clientService = clientService;
            this.voitureService = voitureService;
            this.chauffeurService = chauffeurService;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            return View(courseService.GetAll());
        }
        public ActionResult ListByChauffeur(int id)
        {
            return View(courseService.GetPayedCourses(chauffeurService.GetById(id), DateTime.Now));
        }
        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.Voitures = new SelectList(voitureService.GetAll(), "NumMat", "NumMat");
            ViewBag.Clients = new SelectList(clientService.GetAll(), "CIN", "CIN");

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                courseService.Add(course);
                unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
