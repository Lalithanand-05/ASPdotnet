using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
            public class Employee
        {
            [Key]
            public int EmployeeId { get; set; }
            public string EName { get; set; }
            public string Job { get; set; }
            public int Salary { get; set; }
            public int DeptNo { get; set; }
        }

        public class EmployeeDbContext : DbContext
        {
            public DbSet<Employee> Employees { get; set; }

            public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
             : base(options)
            {

            }

        }
    
}
