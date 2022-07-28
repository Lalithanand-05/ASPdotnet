using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Repository;
using log4net;
using WebApplication4.Filters;
using System.Diagnostics;


namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo _repo;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepo repo,ILogger<EmployeeController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
      

        

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Index()
        {
            _logger.LogInformation("Index Action is Processed.");
            _logger.LogError("Error Message");


            List<Employee> lstEmployees = new List<Employee>();

            lstEmployees[3].EName = "Scott";

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult EmployeeByDeptNo(int deptId)
        {
            IEnumerable<Employee> empList = _repo.GetAllEmployeeByDeptId(deptId);
            return View(empList);
        }

        [HttpPost]
        public IActionResult EmployeeByJob(string job)
        {
            IEnumerable<Employee> empList = _repo.GetEmployeeByJob(job);
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _repo.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee obj = _repo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = _repo.GetEmployeeById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _repo.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _repo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _repo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        
        

        


        

    }

}

