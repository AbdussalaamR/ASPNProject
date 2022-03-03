using ASPNProject.Entities;
using ASPNProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNProject.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ILecturerService _lecturerService;
        private readonly IDeptService _deptService;

        public LecturerController(IDeptService deptService, ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
            _deptService = deptService;
        }
        // GET
        public IActionResult Index()
        {
            return View(_lecturerService.GetLecturers());
        }
        public IActionResult Create()
        {
            var department = _deptService.GetDepartments();
            ViewData["department"] = new SelectList(department, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Lecturer lecturer)
        {
            _lecturerService.RegisterLecturer(lecturer);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDetails(int id)
        {
            var department = _deptService.GetDepartments();
            ViewData["department"] = new SelectList(department, "Id", "Name");
            var lecturer = _lecturerService.GetLecturer(id);
            if (lecturer == null)
            {
                return NotFound();
            }
            else
            {
                return View(lecturer);
            }
        }
        [HttpPost]
        public IActionResult UpdateDetails(Lecturer lecturer, int id)
        {
            _lecturerService.EditLecturer(lecturer, id);
            return RedirectToAction("Index");
        }
    }
}