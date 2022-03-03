using System;
using System.Collections.Generic;
using ASPNProject.Entities;
using ASPNProject.Interfaces;

namespace ASPNProject.Implementation
{
    public class LecturerService:ILecturerService
    {
        private readonly ILecturerRepo _lecturerRepo;

        public LecturerService(ILecturerRepo lecturerRepo)
        {
            _lecturerRepo = lecturerRepo;
        }

        public bool RegisterLecturer(Lecturer lecturer)
        {
            var EmailExists = _lecturerRepo.EmailExist(lecturer.Email);
            if (EmailExists)
            {
                throw new Exception($" Lecturer with {lecturer.Email} already exist");
            }

            var newLecturer = new Lecturer
            {
                FirstName = lecturer.FirstName,
                LastName = lecturer.LastName,
                Email = lecturer.Email,
                Age = lecturer.Age,
                DepartmentId = lecturer.DepartmentId,
                Department = lecturer.Department
            };
            return _lecturerRepo.RegisterLecturer(newLecturer);
        }

        public bool EditLecturer(Lecturer lecturer, int id)
        {
            var updatedLecturer = _lecturerRepo.GetLecturer(id);
            if (updatedLecturer == null)
            {
                throw new Exception($"Lecturer with {id} does not exist");   
            }

            updatedLecturer.FirstName = lecturer.FirstName;
            updatedLecturer.LastName = lecturer.LastName;
            updatedLecturer.Email = lecturer.Email;
            updatedLecturer.Age = lecturer.Age;
            updatedLecturer.DepartmentId = lecturer.DepartmentId;
            _lecturerRepo.EditLecturer(updatedLecturer, id);
            return true;
        }

        public string DeleteLecturer(int id)
        {
            var lecturer = _lecturerRepo.GetLecturer(id);
            if (lecturer == null)
            {
                throw new Exception($"lecturer with {id} does not exist"); 
            }
            _lecturerRepo.DeleteLecturer(id);
            return $"lecturer with {id} deleted successfully";
        }

        public Lecturer GetLecturer(int id)
        {
            return _lecturerRepo.GetLecturer(id);
        }

        public IList<Lecturer> GetLecturers()
        {
            return _lecturerRepo.GetLecturers();
        }

        public bool EmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public IList<Lecturer> GetDeptLecturers(int id)
        {
            return _lecturerRepo.GetDeptLecturers(id);
        }
    }
}