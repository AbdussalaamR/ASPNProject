using System.Collections.Generic;

namespace ASPNProject.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string  Description{ get; set; }
        public List<Lecturer> Lecturers {get; set;} = new List<Lecturer>();

    }
}