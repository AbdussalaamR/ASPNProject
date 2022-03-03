using System.Collections.Generic;
using ASPNProject.Entities;

namespace ASPNProject.Interfaces
{
    public interface ILecturerService
    {
        bool RegisterLecturer(Lecturer lecturer);
        bool EditLecturer(Lecturer lecturer, int id);
        string DeleteLecturer(int id);
        Lecturer GetLecturer(int id);
        IList<Lecturer> GetLecturers();
        bool EmailExist(string email);
        IList<Lecturer> GetDeptLecturers(int id);
    }
}