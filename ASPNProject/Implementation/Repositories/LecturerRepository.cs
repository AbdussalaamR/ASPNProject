using System.Collections.Generic;
using System.Linq;
using ASPNProject.Context;
using ASPNProject.Entities;
using ASPNProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPNProject.Implementation
{
    public class LecturerRepository:ILecturerRepo
    {
        private readonly ApplicationContext _context;

        public LecturerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool RegisterLecturer(Lecturer lecturer)
        {
            _context.Lecturer.Add(lecturer);
            _context.SaveChanges();
            return true;
        }

        public bool EditLecturer(Lecturer lecturer, int id)
        {
            _context.Lecturer.Update(lecturer);
            _context.SaveChanges();
            return true;
        }

        public string DeleteLecturer(int id)
        {
            var lect = _context.Lecturer.Find(id);
            _context.Lecturer.Remove(lect);
            _context.SaveChanges();
            return $"Lecturer with {id} deleted successfully";
        }

        public Lecturer GetLecturer(int id)
        {
            var lect = _context.Lecturer.Find(id);
            return lect;
        }

        public IList<Lecturer> GetLecturers()
        {
            return _context.Lecturer.Include(x => x.Department).ToList();
        }
        public IList<Lecturer> GetDeptLecturers(int id)
        {
            var deptlecturers = _context.Lecturer.Include(x => x.Department).Where(x => x.DepartmentId == id).ToList();
            return deptlecturers;
        }

        public bool EmailExist(string email)
        {
            return _context.Lecturer.Any(x => x.Email == email);
        }

        public bool NamelExist(string name)
        {
            return _context.Lecturer.Any(y => y.FirstName == name);
        }
    }
}