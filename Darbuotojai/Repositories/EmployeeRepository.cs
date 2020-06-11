using Darbuotojai.Models;
using Darbuotojai.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbuotojai.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.AddAsync(employee);

            await _appDbContext.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<Employee> EditEmployee(EditEmployeeViewModel employee)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (result == null) return null;

            result.Address = employee.Address;
            result.BirthDate = employee.BirthDate;
            result.Name = employee.Name;
            result.Surname = employee.Surname;
            result.PersonalIdentification = employee.PersonalIdentification;

            await _appDbContext.SaveChangesAsync();

            return result;
        }

        public async Task<Employee> RemoveEmployee(int id)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (result == null) return null;

            result.State = EmployeeState.Inactive;

            await _appDbContext.SaveChangesAsync();

            return result;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByState(int stateId)
        {
            return await _appDbContext.Employees.Where(e => (int)e.State == stateId).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
