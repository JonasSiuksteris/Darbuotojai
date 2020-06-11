using Darbuotojai.Models;
using Darbuotojai.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Darbuotojai.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<Employee> EditEmployee(EditEmployeeViewModel employee);
        public Task<Employee> RemoveEmployee(int id);
        public Task<List<Employee>> GetEmployees();
        public Task<List<Employee>> GetEmployeesByState(int stateId);
        public Task<Employee> GetEmployeeById(int id);

    }
}
