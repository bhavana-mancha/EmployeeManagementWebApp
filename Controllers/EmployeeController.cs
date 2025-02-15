using EmployeeManagementApp.Models;
using EmployeeManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Empdetails()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Home()
       {
          return View(); 
       }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                TempData["SuccessMessage"] = "Employee added successfully!";
                return RedirectToAction("Home");
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                 TempData["SuccessMessage"] = "Employee details updated successfully!";
                return RedirectToAction("Home");
                
            }
            return View(employee);
        }
public IActionResult Delete(int id)  // GET Method
{
    var employee = _employeeService.GetEmployeeById(id);
    if (employee == null) return NotFound();
    return View(employee);
}

[HttpPost]
public IActionResult ConfirmDelete(int id)  // Renamed POST Method
{
    _employeeService.DeleteEmployee(id);
     TempData["SuccessMessage"] = "Employee deleted successfully!";
    return RedirectToAction("Home");
}


        public IActionResult SearchById()
    {
        return View();
    }

       public IActionResult UpdateSearch()
    {
        return View();
    }

    // Get employee details by ID
    [HttpPost]
    public IActionResult GetEmployeeDetails(int id)
{
    var employee = _employeeService.GetEmployeeById(id);
    if (employee == null)
    {
        ModelState.AddModelError("", "Employee not found.");
        TempData["SuccessMessage"] = "Employee not Found !!!";
        return View("SearchById");
    }

    decimal bonus = 0m;

    // Determine the employee type using the Role property
    switch (employee.Role.ToLower())
    {
        case "intern":
            bonus = new Intern().BonusPercent();
            break;
        case "manager":
            bonus = new Manager().BonusPercent();
            break;
        default:
            bonus = employee.BonusPercent();
            break;
    }

    ViewBag.BonusAmount = employee.Salary*bonus; // Send bonus amount to the view

    return View("EmployeeDetails", employee);
}

public IActionResult UpdateEmployee(int id)
{
    ViewBag.SelectedId = id; 
    var employees = _employeeService.GetAllEmployees(); 
    return View(employees);
}

    }
}