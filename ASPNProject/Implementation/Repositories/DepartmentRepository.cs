using System.Collections.Generic;
using System.Linq;
using ASPNProject.Context;
using ASPNProject.Entities;
using ASPNProject.Interfaces;

namespace ASPNProject.Implementation
{
    public class DepartmentRepository:IDeptRepo
    {
        private readonly ApplicationContext _context;

        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool CreateDept(Department department)
        {
            _context.Department.Add(department);
            _context.SaveChanges();
            return true;
        }

        public bool EditDepartment(Department department, int id)
        {
            _context.Department.Update(department);
            _context.SaveChanges();
            return true;
        }

        public string DeleteDept(int id)
        {
            var dept = _context.Department.Find(id);
            _context.Department.Remove(dept);
            _context.SaveChanges();
            return $"Department with {id} successfully deleted";
        }

        public Department GetDepartment(int id)
        {
            var lecturer = _context.Department.Find(id);
            return lecturer;
        }

        public IList<Department> GetDepartments()
        {
            return _context.Department.ToList();
        }

        public bool NamelExist(string name)
        {
            return _context.Department.Any(x => x.Name == name);
        }
    }
}