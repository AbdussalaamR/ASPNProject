using System;
using System.Collections.Generic;
using System.Linq;
using ASPNProject.Entities;
using ASPNProject.Interfaces;

namespace ASPNProject.Implementation
{
    public class DepartmentService:IDeptService
    {
        private readonly IDeptRepo _deptRepo;

        public DepartmentService(IDeptRepo deptRepo)
        {
            _deptRepo = deptRepo;
        }

        public bool CreateDept(Department department)
        {
            var nameExists = _deptRepo.NamelExist(department.Name);
            if (nameExists)
            {
                throw new Exception($"{department.Name} already exist");
            }
            var newDept = new Department
                {
                    Name = department.Name,
                    Description = department.Description,
                };
            return _deptRepo.CreateDept(newDept);
        }

        public bool EditDepartment(Department department, int id)
        {
            var nameExists = _deptRepo.NamelExist(department.Name);
            var dept = _deptRepo.GetDepartment(id);
            if (dept == null)
            {
                throw new Exception($"department with {id} does not exist");   
            }
            if (nameExists && department.Description == dept.Description)
            {
                throw new Exception($"{department.Name} already exist");
            }
            dept.Name = department.Name;
            dept.Description = department.Description;
            _deptRepo.EditDepartment(dept, id);
             return true;
        }

        public string DeleteDept(int id)
        {
            var dept = _deptRepo.GetDepartment(id);
            if (dept == null)
            {
                throw new Exception($"department with {id} does not exist"); 
            }

            _deptRepo.DeleteDept(id);
            return $"Department with {id} succesfully deleted";
        }

        public Department GetDepartment(int id)
        {
            return _deptRepo.GetDepartment(id);
        }

        public IList<Department> GetDepartments()
        {
            return _deptRepo.GetDepartments();
        }

        public IList<Lecturer> GetDeptLecturers(int id)
        {
            throw new NotImplementedException();
        }

        public bool NamelExist(string name)
        {
            throw new NotImplementedException();
        }
    }
}