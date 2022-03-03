using ASPNProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNProject.Context
{
    public class ApplicationContext:DbContext
    {
          public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
            {
            
            }
            public  DbSet<Lecturer> Lecturer { get; set; }
            public  DbSet<Department> Department { get; set; }
    }
}