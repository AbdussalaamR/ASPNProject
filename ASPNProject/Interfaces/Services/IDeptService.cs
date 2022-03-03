using System.Collections.Generic;
using ASPNProject.Entities;

namespace ASPNProject.Interfaces
{
    public interface IDeptService
    {
        bool CreateDept(Department department);
        bool EditDepartment(Department department, int id);
        string DeleteDept(int id);
        Department GetDepartment(int id);
        IList<Department> GetDepartments();
        bool NamelExist(string name);
    }
}