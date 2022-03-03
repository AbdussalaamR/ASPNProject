using ASPNProject.Entities;
using ASPNProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPNProject.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ILecturerService _lecturerService;
        private readonly IDeptService _deptService;

        public DepartmentController(ILecturerService lecturerService, IDeptService deptService)
        {
            _lecturerService = lecturerService;
            _deptService = deptService;
        }
        // GET
        public IActionResult Index()
        {
            return View(_deptService.GetDepartments());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            _deptService.CreateDept(department);
            return RedirectToAction("Index");
        }
        
        public IActionResult UpdateDeptDetails(int id)
        {
            var dept = _deptService.GetDepartment(id);
            if (dept == null)
            {
                return NotFound();
            }
            else
            {
                return View(dept);
            }
        }
        [HttpPost]
        public IActionResult UpdateDeptDetails(Department department, int id)
        {
            _deptService.EditDepartment(department, id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var dept = _deptService.GetDepartment(id);
            if (dept == null)
            {
                return NotFound($"Dept with {id} not found");
            }
            else
            {
                return View(dept);
            }
        }
        
         
        [HttpPost, ActionName("Delete")] 
        public IActionResult DeleteConfirmed(int id)
        {
            _deptService.DeleteDept(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult ViewDeptLecturers(int id)
        {
            var lecturers = _lecturerService.GetDeptLecturers(id);
            return View(lecturers);
        }
    }
}