using Darbuotojai.Models;
using Darbuotojai.Repositories;
using Darbuotojai.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Darbuotojai.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ViewResult> Index(int showState = 0)
        {
            List<Employee> employees;
            if (showState == 2)
                employees = await _employeeRepository.GetEmployees();
            else
                employees = await _employeeRepository.GetEmployeesByState(showState);

            return View(new EmployeesIndexModel { Employees = employees, ShowState = (EmployeeState)showState });
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel employeeModel)
        {
            if (!ModelState.IsValid) return View("Error", new ErrorViewModel { Error = "Invalid Model State" });

            var newEmployee = new Employee
            {
                Address = employeeModel.Address,
                BirthDate = employeeModel.BirthDate,
                Name = employeeModel.Name,
                Surname = employeeModel.Surname,
                PersonalIdentification = employeeModel.PersonalIdentification
            };
            await _employeeRepository.CreateEmployee(newEmployee);

            return RedirectToAction("Index", "Employee", 0);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            var user = await _employeeRepository.GetEmployeeById(id);

            if (user == null)
            {
                return View("Error", new ErrorViewModel { Error = "Wrong employee id in remove operation" });
            }

            await _employeeRepository.RemoveEmployee(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return View("Error", new ErrorViewModel { Error = $"Wrong employee ID to edit({id})" });
            }

            var model = new EditEmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Address = employee.Address,
                BirthDate = employee.BirthDate,
                PersonalIdentification = employee.PersonalIdentification
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditEmployeeViewModel employeeModel)
        {
            var employee = await _employeeRepository.GetEmployeeById(employeeModel.Id);

            if (employee == null)
            {
                return View("Error", new ErrorViewModel { Error = "Wrong employee model sent to edit" });
            }

            await _employeeRepository.EditEmployee(employeeModel);

            return RedirectToAction("Index");
        }
    }
}
