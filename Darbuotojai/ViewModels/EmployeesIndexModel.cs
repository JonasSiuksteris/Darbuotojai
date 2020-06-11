using Darbuotojai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Darbuotojai.ViewModels
{
    public class EmployeesIndexModel
    {
        public IList<Employee> Employees { get; set; }
        [BindProperty]
        public EmployeeState ShowState { get; set; }
    }
}
