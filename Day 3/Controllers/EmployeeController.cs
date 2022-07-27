using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        
            IEmployeeRepo _repo;
            public EmployeeController(IEmployeeRepo repo)
            {
                _repo = repo;
            }
            public IActionResult Index()
            {
                List<Employee> empList = _repo.GetAllEmployee();
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

