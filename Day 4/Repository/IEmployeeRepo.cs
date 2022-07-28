using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmployee();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee obj);
        void UpdateEmployee(Employee obj);
        void DeleteEmployee(int id);

        IEnumerable<Employee> GetAllEmployeeByDeptId(int deptId)
        { 
            throw new NotImplementedException(); 
        }

        IEnumerable<Employee> GetEmployeeByJob(string job)
        {
            throw new NotImplementedException();
        }

    }
}
